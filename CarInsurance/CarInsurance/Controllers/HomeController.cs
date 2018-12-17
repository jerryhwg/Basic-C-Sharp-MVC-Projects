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
        public ActionResult QuoteForm(string firstName, string lastName, string emailAddress, DateTime dateofBirth, int carYear, string carMake, string carModel, int ticketNumber, bool dui = false, bool coverage = false) // QuoteForm (public partial class QuoteForm in QuoteForm.cs)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(dateofBirth.ToString()) || string.IsNullOrEmpty(carYear.ToString()) || string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(carModel) || string.IsNullOrEmpty(ticketNumber.ToString()) || string.IsNullOrEmpty(dui.ToString()) || string.IsNullOrEmpty(coverage.ToString()))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (CarInsuranceEntities db = new CarInsuranceEntities()) // using CarInsurance.Models for database connection
                {
                    var quote = new QuoteForm(); // Models - QuoteForm.cs (insert data input to database table using Model) / use var because the datatype is obvious
                    quote.FirstName = firstName;
                    quote.LastName = lastName;
                    quote.EmailAddress = emailAddress;
                    quote.DateofBirth = dateofBirth;
                    quote.CarYear = carYear;
                    quote.CarMake = carMake;
                    quote.CarModel = carModel;
                    quote.TicketNumber = ticketNumber;
                    quote.DUI = dui;
                    quote.FullCoverage = coverage;

                    var today = DateTime.Today;
                    var age = today.Year - dateofBirth.Year;

                    var finalQuote = 50m;

                    if (age < 25 && age >= 18)
                    {
                        finalQuote += 25;
                    }
                    else if (age < 18)
                    {
                        finalQuote += 100;
                    }
                    else if (age >= 100)
                    {
                        finalQuote += 25;
                    }

                    if (carYear < 2000)
                    {
                        finalQuote += 25;
                    }
                    else if (carYear >= 2015)
                    {
                        finalQuote += 25;
                    }

                    if (carMake == "Porsche")
                    {
                        finalQuote += 25;
                    }
                    else if (carMake == "Porsche" && carModel == "911 Carrera")
                    {
                        finalQuote += 50;
                    }

                    if (ticketNumber >= 1)
                    {
                        finalQuote = finalQuote + (finalQuote * 10);
                    }
                    else
                    {
                        finalQuote += 0;
                    }

                    if (dui == true)
                    {
                        finalQuote = finalQuote + (finalQuote * .25m);
                    }
                    else
                    {
                        finalQuote += 0;
                    }

                    if (coverage == true)
                    {
                        finalQuote = finalQuote + (finalQuote * .5m);
                    }
                    else
                    {
                        finalQuote += 0;
                    }

                    quote.FinalQuote = finalQuote;

                    db.QuoteForms.Add(quote); // 242:6:42, Models -> CarInsurance.Context.tt -> CarInsurance.Context.cs (= database table name)
                    db.SaveChanges();
                }
                return View("Success");
            }
        }
    }
}