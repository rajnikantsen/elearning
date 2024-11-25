using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alturasphere_learning_Platform.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string Title { get; set; }
        public bool IsOngoing { get; set; }
    }
}