using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alturasphere_learning_Platform.Models
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}