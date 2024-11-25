using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alturasphere_learning_Platform.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsUpcoming { get; set; }
    }
}