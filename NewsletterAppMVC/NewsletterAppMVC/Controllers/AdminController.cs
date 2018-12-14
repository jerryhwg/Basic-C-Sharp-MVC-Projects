using NewsletterAppMVC.Models;
using NewsletterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            // The following shows a simple line replaces the detailed db connection (ADO.NET) by using EF (EntityFramework)
            using (NewsletterEntities db = new NewsletterEntities()) // use db oject to access database / NewsletterEntities from Model1.Context.cs for databasse connection / a best practice to use 'using' to cut off the db connection when done
            {
                //var signups = db.SignUps.Where (x => x.Removed == null).ToList(); // SignUps: property (see Model1.Context.cs) which represents all of records in the database
                // LINQ instead of lambda above to list only subscribed user
                var signups = (from c in db.SignUps
                               where c.Removed == null
                               select c).ToList();
                var signupVms = new List<SignupVm>(); // if it's obvious what the data type is, you don't list it twice, use var instead of List<SignupVm>
                foreach (var signup in signups)
                {
                    var signupVm = new SignupVm();
                    signupVm.Id = signup.Id;
                    signupVm.FirstName = signup.FirstName;
                    signupVm.LastName = signup.LastName;
                    signupVm.EmailAddress = signup.EmailAddress;
                    signupVms.Add(signupVm);
                }

                return View(signupVms); // ViewModels (Model maps to ViewModels)
            }
        }

        public ActionResult Unsubscribe(int Id)
        {
            using (NewsletterEntities db = new NewsletterEntities())
            {
                var signup = db.SignUps.Find(Id);
                signup.Removed = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}