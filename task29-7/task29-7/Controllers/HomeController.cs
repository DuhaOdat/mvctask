using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task29_7.Models;

namespace task29_7.Controllers
{
    public class HomeController : Controller
    {
        CRUDEntities db = new CRUDEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(user_table uSER, string confirmpassword)
        {
            if (ModelState.IsValid && uSER.password == confirmpassword)
            {
                db.user_table.Add(uSER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uSER);
        }

        public ActionResult Login()
        {
            return View();
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(user_table uSER)
        {
            var checkInputs = db.user_table.Where(model => model.email == uSER.email && model.password == uSER.password).FirstOrDefault();

            Session["UserID"] = checkInputs.id;
            

            if (checkInputs != null) { 
               return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session["UserID"] = null;
            return RedirectToAction("Index");
        }



        public ActionResult Profile()
        {
            var userID = (int)Session["UserID"];
            var user = db.user_table.Find(userID);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(user_table uSER, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                if (!Directory.Exists(Server.MapPath("~/Images/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Images/"));
                }

                upload.SaveAs(path);
                uSER.img = fileName;
            }

            db.Entry(uSER).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ResetPasswordt()
        {
            var userID = (int)Session["UserID"];
            var user = db.user_table.Find(userID);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPasswordt(string currentPassword, string newPassword, string confirmNewPassword)
        {
            var userID = (int)Session["UserID"];
            var user = db.user_table.Find(userID);

            if (currentPassword == user.password)
            {
                if (newPassword == confirmNewPassword)
                {
                    user.password = newPassword;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Profile");
                }
                else
                {
                    ViewBag.Message = "New Password does not match Confirm Password!";
                    return View(user);
                }
            }
            else
            {
                ViewBag.Message = "Current Password is incorrect!";
                return View(user);
            }
        }
    }


}
