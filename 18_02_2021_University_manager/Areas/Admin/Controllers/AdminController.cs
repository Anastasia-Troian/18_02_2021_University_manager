using _18_02_2021_University_manager.Models;
using _18_02_2021_University_manager.Models.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _18_02_2021_University_manager.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace _18_02_2021_University_manager.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        private ApplicationDbContext ctx = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Requests()
        {
            IEnumerable<RequestViewModel> m = ctx.Requests.Select(r => new RequestViewModel()
            {
                Id = r.Id,
                StudentId = r.StudentId,
                GroupName = r.GroupName,
                Requests = r.Requests
            });

            IEnumerable<RequestViewModel> models = m.Where(r => r.Requests == Models.Entity.Models.Req.Requested);

            return View(models);
        }

        public ActionResult Accept(int id)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(ctx));
            Request p = ctx.Requests.Find(id);
            p.Requests = Req.Accepted;
            var user = ctx.Students.Find(p.StudentId);
            user.Group = ctx.Groups.FirstOrDefault(x => x.Name == p.GroupName);
            userManager.RemoveFromRole(user.ApplicationUser.Id, "User");
            userManager.AddToRole(user.ApplicationUser.Id , "Student");
            ctx.Requests.Remove(p);
            ctx.SaveChanges();

            return RedirectToAction("Requests");
        }

        public ActionResult Reject(int id)
        {
            Request p = ctx.Requests.Find(id);
            p.Requests = Req.Rejected;
            ctx.SaveChanges();

            return RedirectToAction("Requests");
        }

        public ActionResult Delete(int id)
        {
            ctx.Groups.Remove(ctx.Groups.Find(id));
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        

    }
}