using Alturasphere_learning_Platform.Models;
using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Alturasphere_learning_Platform.Controllers
{
    public class RegistrationController : Controller
    {
        private string connectionString = "Data Source=DESKTOP-G8OQG93\\INSTACE2022;Initial Catalog=E_Learning;Integrated Security=True;";

        [HttpGet]
        public ActionResult Enroll()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Enroll(User user)
        {
            //DateTime date = DateTime.Now;   
            if (ModelState.IsValid) // Validate form data
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO Users (FullName, Email, Phone, Course) VALUES (@FullName, @Email, @Phone, @Course)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@FullName", user.FullName);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@Phone", user.Phone);
                        command.Parameters.AddWithValue("@Course", user.Course);
                        //command.Parameters.AddWithValue("@RegistrationDate", user.date);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    TempData["SuccessMessage"] = "Registration successful!";
                    return RedirectToAction("Success");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Error: " + ex.Message;
                }
            }

            return View(user); // If validation fails, reload form
        }

        public ActionResult Success()
        {
            return View();
        }
        
    }

}
