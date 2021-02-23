using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _18_02_2021_University_manager.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string GroupName { get; set; }

    }
}