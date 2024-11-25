//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//namespace Alturasphere_learning_Platform.Controllers

//{
//    public class HomeController : Controller
//    {
//        // GET: Home
//        private readonly string connectionString = ConfigurationManager.ConnectionStrings["E_LearningDB"].ConnectionString;

//        public ActionResult Index()
//        {
//            return View();
//        }
//        public ActionResult About()
//        {
//            return View();
//        }
//        public ActionResult Login()
//        {
//            return View();
//        }
//        public ActionResult Training()
//        {
//            return View();
//        }
//        public ActionResult Contact()
//        {
//            return View();
//        }
//        [SessionCheck]
//        public ActionResult Dashboard()
//        {
//            return View();
//        }
//        [SessionCheck]
//        public ActionResult Inbox()
//        {
//            return View();
//        }
//        [SessionCheck]
//        public ActionResult Lesson()
//        {
//            return View();
//        }
//        [SessionCheck]
//        public ActionResult Task()
//        {
//            return View();
//        }


//        [SessionCheck]

//        public ActionResult Overview()
//        {
//            ViewBag.CompletedCourses = GetCompletedCoursesCount();
//            ViewBag.OngoingLessons = GetOngoingLessonsCount();
//            ViewBag.UpcomingTasks = GetUpcomingTasksCount();
//            ViewBag.Progress = CalculateProgress();
//            ViewBag.Announcements = GetAnnouncements();

//            return View();
//        }

//        private int GetCompletedCoursesCount()
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Courses WHERE IsCompleted = 1", connection);
//                return (int)command.ExecuteScalar();
//            }
//        }

//        private int GetOngoingLessonsCount()
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Lessons WHERE IsOngoing = 1", connection);
//                return (int)command.ExecuteScalar();
//            }
//        }

//        private int GetUpcomingTasksCount()
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Tasks WHERE DueDate > GETDATE()", connection);
//                return (int)command.ExecuteScalar();
//            }
//        }

//        private int CalculateProgress()
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                SqlCommand command = new SqlCommand(
//                    "SELECT (CAST(SUM(CASE WHEN IsCompleted = 1 THEN 1 ELSE 0 END) AS FLOAT) / COUNT(*)) * 100 AS Progress FROM Courses",
//                    connection
//                );
//                return (int)command.ExecuteScalar();
//            }
//        }

//        private List<string> GetAnnouncements()
//        {
//            List<string> announcements = new List<string>();
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                SqlCommand command = new SqlCommand("SELECT Message FROM Announcements", connection);
//                SqlDataReader reader = command.ExecuteReader();

//                while (reader.Read())
//                {
//                    announcements.Add(reader["Message"].ToString());
//                }
//            }
//            return announcements;
//        }
//        [SessionCheck]
//        public ActionResult Group()
//        {
//            return View();
//        }
//        [SessionCheck]
//        public ActionResult Interview()
//        {
//            return View();
//        }
//        [SessionCheck]
//        public ActionResult Settings()
//        {
//            return View();
//        }

//        public ActionResult Course()
//        {
//            return View();
//        }

//        public ActionResult Internship()
//        {
//            return View();
//        }

//        public ActionResult Registration()
//        {
//            return View();
//        }
//        [SessionCheck]
//        public ActionResult Logout()
//        {
//            return View();
//        }
//        public ActionResult Logoutall()
//        {
//            Session.Clear();
//            return RedirectToAction("Login", "Account");
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Alturasphere_learning_Platform.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["E_LearningDB"].ConnectionString;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Mentor1()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Training()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [SessionCheck]
        public ActionResult Dashboard()
        {
            return View();
        }

        [SessionCheck]
        public ActionResult Inbox()
        {
            return View();
        }

        [SessionCheck]
        public ActionResult Lesson()
        {
            return View();
        }

        [SessionCheck]
        public ActionResult Task()
        {
            return View();
        }

        [SessionCheck]
        public ActionResult Overview()
        {
            // Fetch data from the database and pass it to the ViewBag
            ViewBag.CompletedCourses = GetCompletedCoursesCount();
            ViewBag.OngoingLessons = GetOngoingLessonsCount();
            ViewBag.UpcomingTasks = GetUpcomingTasksCount();
            ViewBag.Progress = CalculateProgress();
            ViewBag.Announcements = GetAnnouncements();

            return View();
        }

        private int GetCompletedCoursesCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Courses WHERE IsCompleted = 1", connection);

                object result = command.ExecuteScalar();
                return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        private int GetOngoingLessonsCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Lessons WHERE IsOngoing = 1", connection);

                object result = command.ExecuteScalar();
                return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        private int GetUpcomingTasksCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Tasks WHERE DueDate > GETDATE()", connection);

                object result = command.ExecuteScalar();
                return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        private int CalculateProgress()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    @"SELECT (CAST(SUM(CASE WHEN IsCompleted = 1 THEN 1 ELSE 0 END) AS FLOAT) / COUNT(*)) * 100 AS Progress 
                      FROM Courses",
                    connection
                );

                object result = command.ExecuteScalar();
                return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        private List<string> GetAnnouncements()
        {
            List<string> announcements = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Message FROM Announcements", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    announcements.Add(reader["Message"].ToString());
                }
            }
            return announcements;
        }

        [SessionCheck]
        public ActionResult Group()
        {
            return View();
        }

        [SessionCheck]
        public ActionResult Interview()
        {
            return View();
        }

        [SessionCheck]
        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult Course()
        {
            return View();
        }

        public ActionResult Internship()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        [SessionCheck]
        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult Logoutall()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
