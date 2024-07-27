using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace generalMvcTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
            
            Session["isLogged"] ="false";
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }
        public ActionResult Contact()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Contact(string name, string id, string email,string gender, string message)
        {
            Session["name"] = name;
            Session["id"] = id;
            Session["email"] = email;
            Session["gender"] = gender;
          Session["message"] = message;


            return View("Contact");
        }
        public ActionResult Login()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
          string email=form["email"];
          string password =form["password"];
            if (email=="odatduha@gmail.com" && password=="1234")
            {
                Session["isLogged"] = "true";
                ViewData["name"] ="Duha";
               
            }

            return View("Index");
        }
        public ActionResult Logout()
        {


            return View();
        }
       



    }
}