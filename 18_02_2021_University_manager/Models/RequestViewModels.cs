using _18_02_2021_University_manager.Models.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _18_02_2021_University_manager.Models
{
    public class RequestViewModel
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public string GroupName { get; set; }

        [Required]
        public Req Requests { get; set; }
    }
}