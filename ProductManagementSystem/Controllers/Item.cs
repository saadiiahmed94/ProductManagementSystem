using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductManagementSystem.Models;
namespace ProductManagementSystem.Controllers
{
    public class Item
    {

        private Product p = new Product();
        private int quantity;
        
        
        public Item()
        {

        }
        
        
        public Item(Product p , int quantity)
        {
            this.Pr = p;
                this.Quantity = quantity;
        }

        public Product Pr
        {
            get
            {return p;}
            set
            { p = value;}
        }

        public int Quantity
        {
            get
            { return quantity;}
            set
            {quantity = value;}
        }
    }
}