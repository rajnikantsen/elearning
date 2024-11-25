using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alturasphere_learning_Platform.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}