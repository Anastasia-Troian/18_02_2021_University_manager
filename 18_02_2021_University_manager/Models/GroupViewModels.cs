using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _18_02_2021_University_manager.Models
{
    public class GroupViewModels
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}