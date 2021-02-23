using _18_02_2021_University_manager.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _18_02_2021_University_manager.Areas.Student.Controllers
{
    public class ClassmatesController : Controller
    {
        // GET: Student/Classmates
        private ApplicationDbContext ctx = new ApplicationDbContext();

        [Authorize(Roles = "Student")]
        public ActionResult ClassmatesList()
        {
            var user = ctx.Users.Find(User.Identity.GetUserId());
            IEnumerable<StudentViewModel> students = ctx.Students.Select(x => new StudentViewModel
            {
                Id = x.Id,
                Email = x.ApplicationUser.Email,
                PhoneNumber = x.ApplicationUser.PhoneNumber,
                Image = x.Image,
                GroupName = x.Group.Name
            }).Where(s=>s.GroupName == user.Student.Group.Name );
            return View(students);
        }
    }
}