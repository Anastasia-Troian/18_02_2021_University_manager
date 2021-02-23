using _18_02_2021_University_manager.Models.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _18_02_2021_University_manager.Models.Entity
{
    public class Initializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Groups.Add(new Group { Name = "22-O" });
            context.Groups.Add(new Group { Name = "11-O" });
            context.Groups.Add(new Group { Name = "23-IP" });
            context.Groups.Add(new Group { Name = "41-Z" });
            context.Groups.Add(new Group { Name = "5-O" });
            base.Seed(context);
        }
    }
}