using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoInsurance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new AutoInsurance())
            {
                var driver = new Drivers()
                {
                    FirstName = "Steve",
                    LastName = "Jobs",
                    EmailAddress = "stevejobs@example.com"
                };
                db.Drivers.Add(driver);
                db.SaveChanges();
            }
            return View();
        }
    }
}