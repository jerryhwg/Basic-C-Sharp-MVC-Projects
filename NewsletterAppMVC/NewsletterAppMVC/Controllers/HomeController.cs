using NewsletterAppMVC.Models;
using NewsletterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterAppMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string emailAddress) // SignUp: method name, SingUp.cs in Models
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                // The following shows a simple line replaces the detailed db connection (ADO.NET) by using EF (EntityFramework)
                using (NewsletterEntities db = new NewsletterEntities())
                {
                    var signup = new SignUp(); // SignUp: Model > SignUp.cs (class, datatype)
                    signup.FirstName = firstName; // map the property for the object to the parameter that came in
                    signup.LastName = lastName;
                    signup.EmailAddress = emailAddress;

                    db.SignUps.Add(signup); // SignUps (Models > Model1.Context.tt > Model1.Context.cs: public virtual DbSet<SignUp> SignUps { get; set; })
                    db.SaveChanges();
                }
                // The following is db connection without Entity framework
                //string queryString = @"INSERT INTO SignUps (FirstName, LastName, EmailAddress) VALUES (@FirstName, @LastName, @EmailAddress)"; // prevent raw sql input

                //using (SqlConnection connection = new SqlConnection(connectionString)) // use 'using' statement to cut off the connection when done to prevent memory leak
                //{
                //    SqlCommand command = new SqlCommand(queryString, connection);
                //    command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                //    command.Parameters.Add("@LastName", SqlDbType.VarChar);
                //    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);

                //    command.Parameters["@FirstName"].Value = firstName;
                //    command.Parameters["@LastName"].Value = lastName;
                //    command.Parameters["@EmailAddress"].Value = emailAddress;

                //    connection.Open();
                //    command.ExecuteNonQuery();
                //    connection.Close();
                //}

                return View("Success");
            }
        }
    }
}