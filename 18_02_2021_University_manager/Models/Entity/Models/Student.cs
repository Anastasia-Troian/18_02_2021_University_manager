using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _18_02_2021_University_manager.Models.Entity.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Image { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public virtual Group Group { get; set; }
        public int? GroupId { get; set; }

        public string AplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}