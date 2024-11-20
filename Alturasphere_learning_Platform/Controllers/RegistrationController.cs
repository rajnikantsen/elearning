using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Alturasphere_learning_Platform.Models;
using System.Configuration;


namespace Alturasphere_learning_Platform.Controllers
{

    // GET: Registration
    public class RegistrationController : Controller
    {
        // Handle form submission (POST)
        [HttpPost]
        public ActionResult Enroll(User user)
        {
            DateTime date = DateTime.Now;
            if (ModelState.IsValid)  // Ensure the data is valid before inserting into the database
            {
                try
                {
                    // Retrieve the connection string from web.config
                    string connectionString = ConfigurationManager.ConnectionStrings["E_LearningDB"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO Users (FullName, Email, Phone, Course, RegistrationDate) VALUES (@FullName, @Email, @Phone, @Course, @RegistrationDate)";
                        SqlCommand command = new SqlCommand(query, connection);

                        // Add parameters to the SQL command
                        command.Parameters.AddWithValue("@FullName", user.FullName);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@Phone", user.Phone);
                        command.Parameters.AddWithValue("@Course", user.Course);
                        command.Parameters.AddWithValue("@RegistrationDate", date);
                        // Open connection and execute the insert query
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            // Successfully inserted
                            TempData["SuccessMessage"] = "You have successfully enrolled!";
                            return RedirectToAction("Success");  // Redirect to success page
                        }
                        else
                        {
                            // If no rows are affected, handle the failure
                            TempData["ErrorMessage"] = "There was an error saving your details. Please try again.";
                            return RedirectToAction("Enroll");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (for debugging purposes) or show a message
                    TempData["ErrorMessage"] = "Error: " + ex.Message;
                    return RedirectToAction("Enroll");
                }
            }

            // If validation fails, return the same view with validation errors
            return View(user);
        }

        // Success page after successful enrollment
        public ActionResult Success()
        {
            return View();
        }
    }
}

