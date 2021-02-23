using _18_02_2021_University_manager.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _18_02_2021_University_manager.Helpers
{
    public class SeederDatabase
    {
        public static void SeedDate()
        {
            var ctx = new ApplicationDbContext();
            SeedUsers(ctx);
        }

        private static void SeedUsers(ApplicationDbContext ctx)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
            if (!roleManager.Roles.Any())
            {
                IdentityRole roleAdmin = new IdentityRole()
                {
                    Name = "Admin",
                };

                IdentityRole roleUser = new IdentityRole()
                {
                    Name = "User",
                };

                IdentityRole roleStudent = new IdentityRole()
                {
                    Name = "Student",
                };
                roleManager.Create(roleAdmin);
                roleManager.Create(roleUser);
                roleManager.Create(roleStudent);
            }

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(ctx));
            if (!userManager.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"
                };

                userManager.Create(user, "Qwerty1-");
                userManager.AddToRole(user.Id, "Admin");
            }

        }

    }
}