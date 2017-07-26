using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ProductManagementSystem.Models;


namespace ProductManagementSystem.Controllers
{
   
    [OverrideAuthentication]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string name,string pass)
        {
            PMS pms = new PMS();
            Customer c = new Customer();
            c.customer_name = name;
            c.customer_pass = pass;
           
            pms.Customers.Add(c);
            pms.SaveChanges();



            return RedirectToAction("Index", "Login");
        }
    }



}