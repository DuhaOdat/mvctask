using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication3_eco.Controllers
{
    public class ecommerceController : Controller
    {
        // GET: ecommerce
        public ActionResult shop()
        {
            var products = Session["products"] as List<Product> ?? new List<Product>();
            return View(products);
        }

        // GET: ecommerce/Create
        public ActionResult addProduct()
        {
            return View();
        }

        // POST: ecommerce/Create
        [HttpPost]
        public ActionResult addProduct(string img, string productName, string price)
        {
            var products = Session["products"] as List<Product> ?? new List<Product>();

            
            products.Add(new Product
            {
                ImageUrl = img,
                Name = productName,
                Price = price
            });

            
            Session["products"] = products;

            return RedirectToAction("shop");
        }
    }

    public class Product
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
