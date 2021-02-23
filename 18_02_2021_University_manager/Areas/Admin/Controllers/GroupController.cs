using _18_02_2021_University_manager.Models;
using _18_02_2021_University_manager.Models.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _18_02_2021_University_manager.Areas.Admin.Controllers
{
    public class GroupController : Controller
    {
        // GET: Admin/Group
        private ApplicationDbContext ctx = new ApplicationDbContext();
        public ActionResult GetAllGroups()
        {
            IEnumerable<GroupViewModels> models = ctx.Groups.Select(m => new GroupViewModels()
            {
                Id = m.Id,
                Name = m.Name
            });
            return View(models);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add(GroupViewModels pt)
        {
            ctx.Groups.Add(new Group
            {
                Name = pt.Name
            });
            ctx.SaveChanges();
            return RedirectToAction("GetAllGroups");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Group p = ctx.Groups.Find(id);
            GroupViewModels model = new GroupViewModels()
            {
                Id = p.Id,
                Name = p.Name
            };
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(GroupViewModels pt)
        {
            Group p = ctx.Groups.Find(pt.Id);
            p.Name = pt.Name;
            ctx.SaveChanges();
            return RedirectToAction("GetAllGroups");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            ctx.Groups.Remove(ctx.Groups.Find(id));
            ctx.SaveChanges();
            return RedirectToAction("GetAllGroups");
        }

    }
}