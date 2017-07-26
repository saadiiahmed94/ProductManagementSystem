using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagementSystem.Models;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;

namespace ProductManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return RedirectToAction("Profilee", "Login", new { username = Session["username"].ToString() });
            }
            else
            {
                return View();

            }
        }

        [HttpPost]
        [AllowAnonymous]

        public ActionResult Index(Customer cust)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["PMS"].ConnectionString;
                using (var connection = new SqlConnection(cs))
                {
                    string commandText = "SELECT * FROM [Customer] WHERE customer_name=@customer_name AND customer_pass = @customer_pass";
                    using (var command = new SqlCommand(commandText, connection))
                    {

                        command.Parameters.AddWithValue("@customer_name", cust.customer_name);
                        command.Parameters.AddWithValue("@customer_pass", cust.customer_pass);
                        connection.Open();

                         var userName = command.ExecuteScalar();
                        if ( userName != null)
                        {
                            Session["username"] = cust.customer_name;
                            FormsAuthentication.SetAuthCookie(cust.customer_name, true);
                            return RedirectToAction("Profilee", "Login", new { username = Session["username"].ToString() });
                        }

                        TempData["Message"] = "Login failed.User name or password supplied doesn't exist.";

                        connection.Close();

                    }

                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Login failed.Error - " + ex.Message;



            }
            return RedirectToAction("Index");

        }

        public ActionResult Profilee(Customer cust,string searchTerm)
        {
            PMS pms = new PMS();
            List<Product> p;
            if (Session["username"] == null)
            {
                return RedirectToAction("Index");
            }
            else if(string.IsNullOrEmpty(searchTerm))
            {
                p = pms.Products.Take(30).ToList();
                ViewBag.username = cust.customer_name;


            }
            else
            {
                p = pms.Products.Where(x => x.product_name.StartsWith(searchTerm)).ToList();
                ViewBag.username = cust.customer_name;
                return View("Profilee", p);
            }
            ViewBag.username = cust.customer_name;
            return View("Profilee", p);

        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }

        
        


    }
}