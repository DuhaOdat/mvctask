using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult doctors()
        {
            var doctors = new List<Doctor>
        {
            new Doctor { Name = "Dr. John Doe", Specialty = "Cardiologist"},
            new Doctor { Name = "Dr. Jane Smith", Specialty = "Neurologist" },
            new Doctor { Name = "Dr. Emily Davis", Specialty = "Pediatrician"}
        };

            return View(doctors);
        }


        public ActionResult departments()
        {
            return View();
        }
    }

    public class Doctor
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
      
    }
}