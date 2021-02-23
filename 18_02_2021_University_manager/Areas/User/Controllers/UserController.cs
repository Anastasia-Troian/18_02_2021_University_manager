using _18_02_2021_University_manager.Models;
using _18_02_2021_University_manager.Models.Entity.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _18_02_2021_University_manager.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        // GET: User/User
        private ApplicationDbContext ctx = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SentRequest(string name)
        {
            var user = ctx.Users.Find(User.Identity.GetUserId());
                ctx.Requests.Add(new Request
                {
                    GroupName = name,
                    StudentId = user.Student.Id,
                    Requests = Req.Requested
                });
                ctx.SaveChanges();
            return RedirectToAction("Index", "User");


        }
    }
}