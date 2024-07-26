using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task2MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {
            Session["id"] = form["id"];
            Session["name"] = form["name"];
            Session["email"] = form["email"];
            Session["password"]=form["password"];
            Session["gender"] = form["gender"];
            Session["courses"] = form["courses"];


            return View("ShowContact");
        }

        //another way
        //[HttpPost]
        //public ActionResult Contact(string id,string name,string email,string password,string gender,string courses)
        //{
        //    Session["id"] = id;
        //    Session["name"] = name;
        //    Session["email"] = email;
        //    Session["password"] = password;
        //    Session["gender"]=gender;
        //    Session["courses"] = courses;

        //    return View("ShowContact");
        //}
        public ActionResult ShowContact()
        {

            
            return View();
        }
    }
}