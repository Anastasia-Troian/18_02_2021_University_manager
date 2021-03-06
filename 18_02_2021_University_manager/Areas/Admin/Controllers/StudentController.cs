using _18_02_2021_University_manager.Helpers;
using _18_02_2021_University_manager.Models;
using _18_02_2021_University_manager.Models.Entity.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _18_02_2021_University_manager.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        // GET: Admin/Student
        private ApplicationDbContext ctx = new ApplicationDbContext();
        public ActionResult GetAllStudents()
        {
            IEnumerable<StudentViewModel> students = ctx.Students.Select(x => new StudentViewModel
            {
                Id = x.Id,
                Email = x.ApplicationUser.Email,
                PhoneNumber = x.ApplicationUser.PhoneNumber,
                Image = x.Image,
                GroupName = x.Group.Name
            });
            return View(students);

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Models.Entity.Models.Student p = ctx.Students.Find(id);
            StudentViewModel model = new StudentViewModel()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                SecondName = p.SecondName,
                Email = p.ApplicationUser.Email,
                PhoneNumber = p.ApplicationUser.PhoneNumber,
                GroupName = p.Group.Name,
                Image = p.Image
            };
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(StudentViewModel pt, HttpPostedFileBase imageFile)
        {
            var n = ctx.Groups.FirstOrDefault(x => x.Name == pt.GroupName);
            if (imageFile != null)
            {
                string fileName = Guid.NewGuid().ToString() + ".jpg";
                string image = Server.MapPath(Constants.ImagePath) + "\\" + fileName;
                using (Bitmap bmp = new Bitmap(imageFile.InputStream))
                {
                    Bitmap saveImage = ImageWorker.CreateImage(bmp, 400, 400);
                    if (saveImage != null)
                    {
                        Models.Entity.Models.Student p = ctx.Students.Find(pt.Id);
                        p.Id = pt.Id;
                        p.FirstName = pt.FirstName;
                        p.SecondName = pt.SecondName;
                        p.ApplicationUser.Email = pt.Email;
                        p.ApplicationUser.PhoneNumber = pt.PhoneNumber;
                        p.GroupId = n.Id;
                        p.Image = fileName;
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                Models.Entity.Models.Student p = ctx.Students.Find(pt.Id);
                p.Id = pt.Id;
                p.FirstName = pt.FirstName;
                p.SecondName = pt.SecondName;
                p.ApplicationUser.Email = pt.Email;
                p.ApplicationUser.PhoneNumber = pt.PhoneNumber;
                p.GroupId = n.Id;
                p.Image = p.Image;
                ctx.SaveChanges();
            }
            return RedirectToAction("GetAllGroups");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var st = ctx.Students.Find(id).ApplicationUser;
            ctx.Students.Remove(ctx.Students.Find(id));
            ctx.Users.Remove(st);
            ctx.SaveChanges();
            return RedirectToAction("GetAllStudents");
        }

    }
}