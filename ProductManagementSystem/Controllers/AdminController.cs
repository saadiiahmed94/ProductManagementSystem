using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagementSystem.Models;


namespace ProductManagementSystem.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        PMS pms = new PMS();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(string product_name , decimal product_price)
        {
            if (ModelState.IsValid)
            {
                Product p = new Product();
                p.product_name = product_name;
                p.product_price = product_price;
                pms.Products.Add(p);
                pms.SaveChanges();

            }
            else
            {
                 HttpException.CreateFromLastError("Something went wrong");
               
            }
            return View("Index");
        }


        public ActionResult Update(string searchTerm)
        {
            List<Product> p = new List<Product>();

            if (searchTerm == null)
            {
                p = pms.Products.Take(30).ToList();
                return View(p);
            }
            else
            {
                p = pms.Products.Where(x => x.product_name.StartsWith(searchTerm)).ToList();
                return View("Update", p);
            }
        }
        [HttpPost]
       public ActionResult Update(int product_id ,string product_name,decimal product_price)
        {
            List<Product> p = new List<Product>();

            var s = pms.Products.Find(product_id);

            s.product_name = product_name;
            var o = s.product_price;
            s.product_price = product_price;
            pms.SaveChanges();
            p = pms.Products.Take(30).ToList();

            return View(p);
        }


        public ActionResult Delete(Customer cust, string searchTerm)
        {
            List<Product> p = new List<Product>();
            if (searchTerm == null)
            {
                p = pms.Products.Take(30).ToList();
                return View(p);
            }
            else
            {
                
                p = pms.Products.Where(x => x.product_name.StartsWith(searchTerm)).ToList();
                ViewBag.username = cust.customer_name;
                return View("Delete", p);


            }
        }

        public ActionResult DeletetheProduct(int? id)
        {
            var p = pms.Products.Find(id);
            if (p !=null)
            {
                pms.Products.Remove(p);
                pms.SaveChanges();
                return View("Index");
            }
            return View();
        }

       


    }
}