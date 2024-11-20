using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alturasphere_learning_Platform.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Course { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}