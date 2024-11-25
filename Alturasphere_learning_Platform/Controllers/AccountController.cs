//using System;
//using System.Data.SqlClient;
//using System.Web.Mvc;

//namespace Alturasphere_learning_Platform.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly string connectionString = "Data Source=DESKTOP-G8OQG93\\INSTACE2022;Initial Catalog=E_Learning;Integrated Security=True;Encrypt=False;";

//        [HttpGet]
//        public ActionResult Login(string returnUrl)
//        {
//            ViewBag.ReturnUrl = returnUrl;
//            return View();
//        }


//        [HttpPost]
//        public ActionResult Login(string UserID, string UserName, string returnUrl)
//        {
//            if (string.IsNullOrEmpty(UserID) || string.IsNullOrEmpty(UserName))
//            {
//                TempData["ErrorMessage"] = "UserID and UserName are required.";
//                return RedirectToAction("Login");
//            }

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    string query = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID AND FullName = @UserName";
//                    using (SqlCommand command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@UserID", UserID);
//                        command.Parameters.AddWithValue("@UserName", UserName);

//                        int count = Convert.ToInt32(command.ExecuteScalar());

//                        if (count > 0)
//                        {
//                            Session["UserID"] = UserID;
//                            Session["UserName"] = UserName;

//                            if (!string.IsNullOrEmpty(returnUrl))
//                            {
//                                return Redirect(returnUrl);
//                            }

//                            return RedirectToAction("Dashboard", "Account");
//                        }
//                        else
//                        {
//                            TempData["ErrorMessage"] = "Invalid UserID or UserName.";
//                            return RedirectToAction("Login");
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
//                    return RedirectToAction("Login");
//                }
//            }
//        }
//        //public ActionResult Dashboard()
//        //{
//        //    if (Session["UserID"] == null)
//        //        return RedirectToAction("Login");

//        //    ViewBag.UserName = Session["UserName"];
//        //    return View();
//        //}
//        public ActionResult Dashboard()
//        {
//            if (Session["UserID"] == null)
//                return RedirectToAction("Login");

//            var userID = Session["UserID"].ToString();

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                // Get the number of completed courses
//                string completedCoursesQuery = "SELECT COUNT(*) FROM UserCourses WHERE UserID = @UserID AND Status = 'Completed'";
//                SqlCommand cmdCompletedCourses = new SqlCommand(completedCoursesQuery, connection);
//                cmdCompletedCourses.Parameters.AddWithValue("@UserID", userID);
//                int completedCourses = Convert.ToInt32(cmdCompletedCourses.ExecuteScalar());

//                // Get the number of ongoing lessons
//                string ongoingLessonsQuery = "SELECT COUNT(*) FROM Lessons WHERE Status = 'Ongoing' AND CompletionDate IS NULL";
//                SqlCommand cmdOngoingLessons = new SqlCommand(ongoingLessonsQuery, connection);
//                int ongoingLessons = Convert.ToInt32(cmdOngoingLessons.ExecuteScalar());

//                // Get the number of upcoming tasks
//                string upcomingTasksQuery = "SELECT COUNT(*) FROM Tasks WHERE UserID = @UserID AND DueDate > @Today AND Status = 'Pending'";
//                SqlCommand cmdUpcomingTasks = new SqlCommand(upcomingTasksQuery, connection);
//                cmdUpcomingTasks.Parameters.AddWithValue("@UserID", userID);
//                cmdUpcomingTasks.Parameters.AddWithValue("@Today", DateTime.Now);
//                int upcomingTasks = Convert.ToInt32(cmdUpcomingTasks.ExecuteScalar());

//                // Calculate progress (percentage of completed courses)
//                string totalCoursesQuery = "SELECT COUNT(*) FROM Courses";
//                SqlCommand cmdTotalCourses = new SqlCommand(totalCoursesQuery, connection);
//                int totalCourses = Convert.ToInt32(cmdTotalCourses.ExecuteScalar());
//                double progress = (totalCourses > 0) ? (completedCourses / (double)totalCourses) * 100 : 0;

//                //anouncement code 

//                // Pass data to View
//                ViewBag.CompletedCourses = completedCourses;
//                ViewBag.OngoingLessons = ongoingLessons;
//                ViewBag.UpcomingTasks = upcomingTasks;
//                ViewBag.Progress = progress;

//                return View();
//            }
//        }

//        // Logout Method
//        public ActionResult Logout()
//        {
//            Session.Clear();
//            return RedirectToAction("Login", "Account");
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Alturasphere_learning_Platform.Controllers
{
    public class AccountController : Controller
    {
        private readonly string connectionString = "Data Source=DESKTOP-G8OQG93\\INSTACE2022;Initial Catalog=E_Learning;Integrated Security=True;Encrypt=False;";

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserID, string UserName, string returnUrl)
        {
            if (string.IsNullOrEmpty(UserID) || string.IsNullOrEmpty(UserName))
            {
                TempData["ErrorMessage"] = "UserID and UserName are required.";
                return RedirectToAction("Login");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID AND FullName = @UserName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@UserName", UserName);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            Session["UserID"] = UserID;
                            Session["UserName"] = UserName;

                            if (!string.IsNullOrEmpty(returnUrl))
                            {
                                return Redirect(returnUrl);
                            }

                            return RedirectToAction("Dashboard", "Account");
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Invalid UserID or UserName.";
                            return RedirectToAction("Login");
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                    return RedirectToAction("Login");
                }
            }
        }

        public ActionResult Dashboard()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Login");

            var userID = Session["UserID"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Get the number of completed courses
                string completedCoursesQuery = "SELECT COUNT(*) FROM UserCourses WHERE UserID = @UserID AND Status = 'Completed'";
                SqlCommand cmdCompletedCourses = new SqlCommand(completedCoursesQuery, connection);
                cmdCompletedCourses.Parameters.AddWithValue("@UserID", userID);
                int completedCourses = Convert.ToInt32(cmdCompletedCourses.ExecuteScalar());

                // Get the number of ongoing lessons
                string ongoingLessonsQuery = "SELECT COUNT(*) FROM Lessons WHERE Status = 'Ongoing' AND CompletionDate IS NULL";
                SqlCommand cmdOngoingLessons = new SqlCommand(ongoingLessonsQuery, connection);
                int ongoingLessons = Convert.ToInt32(cmdOngoingLessons.ExecuteScalar());

                // Get the number of upcoming tasks
                string upcomingTasksQuery = "SELECT COUNT(*) FROM Tasks WHERE UserID = @UserID AND DueDate > @Today AND Status = 'Pending'";
                SqlCommand cmdUpcomingTasks = new SqlCommand(upcomingTasksQuery, connection);
                cmdUpcomingTasks.Parameters.AddWithValue("@UserID", userID);
                cmdUpcomingTasks.Parameters.AddWithValue("@Today", DateTime.Now);
                int upcomingTasks = Convert.ToInt32(cmdUpcomingTasks.ExecuteScalar());

                // Calculate progress (percentage of completed courses)
                string totalCoursesQuery = "SELECT COUNT(*) FROM Courses";
                SqlCommand cmdTotalCourses = new SqlCommand(totalCoursesQuery, connection);
                int totalCourses = Convert.ToInt32(cmdTotalCourses.ExecuteScalar());
                double progress = (totalCourses > 0) ? (completedCourses / (double)totalCourses) * 100 : 0;

                // Announcements
                string announcementsQuery = "SELECT Message FROM Announcements ORDER BY CreatedDate DESC";
                SqlCommand cmdAnnouncements = new SqlCommand(announcementsQuery, connection);
                List<string> announcements = new List<string>();
                SqlDataReader reader = cmdAnnouncements.ExecuteReader();
                while (reader.Read())
                {
                    announcements.Add(reader["Message"].ToString());
                }

                // Pass data to View
                ViewBag.CompletedCourses = completedCourses;
                ViewBag.OngoingLessons = ongoingLessons;
                ViewBag.UpcomingTasks = upcomingTasks;
                ViewBag.Progress = progress;
                ViewBag.Announcements = announcements;

                return View();
            }
        }

        // Logout Method
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}

