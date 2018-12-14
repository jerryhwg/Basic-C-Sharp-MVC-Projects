using CarInsurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Application(string firstName, string lastName, string emailAddress, DateTime birthDate, short carYear, string carMake, string carModel, bool dui, int numOfTicket, bool coverage)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(birthDate.ToString()) || string.IsNullOrEmpty(carYear.ToString()) || string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(carModel) || string.IsNullOrEmpty(dui.ToString()) || string.IsNullOrEmpty(numOfTicket.ToString()) || string.IsNullOrEmpty(coverage.ToString()) )
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (CarInsuranceEntities db = new CarInsuranceEntities())
                {
                    

                    var application = new ApplicationForm(); // ApplicationForm: class (datatype)
                    application.FirstName = firstName; // varchar - string
                    application.LastName = lastName; // varchar - string
                    application.EmailAddress = emailAddress; // varchar - string
                    application.DateofBirth = birthDate; // date - DateTime
                    application.CarYear = carYear; // smallint - short
                    application.CarMake = carMake; // varchar - string
                    application.DUI = dui; // bit - bool
                    application.NumberOfSpeedTicket = numOfTicket; // int - int
                    application.FullOrLiability = coverage; // bit - bool

                    db.ApplicationForms.Add(application); // add the inputs to database tables
                    db.SaveChanges(); // database save
                }
                return View("Success");
            }
        }
    }
}