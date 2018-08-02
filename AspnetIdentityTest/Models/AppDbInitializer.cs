using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspnetIdentityTest.Models
{
    public class AppDbInitializer: DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context));

            var roleAdmin = new IdentityRole(){Name = "admin"};
            var roleOperator = new IdentityRole() {Name = "operator"};
            var roleExecutor = new IdentityRole() { Name = "executor" };

            roleManager.Create(roleAdmin);
            roleManager.Create(roleOperator);
            roleManager.Create(roleExecutor);

            var admin = new ApplicationUser()
            {
                Email = "mail@gmail.com",
                UserName = "Overmind"
            };
            var passw = "hamster";
            var res = userManager.Create(admin, passw);

            if (res.Succeeded)
            {
                userManager.AddToRole(admin.Id, roleAdmin.Name);
            }

            var req = new SupportRequest(){OperatorName = "Oper2"};
            var req1 = new SupportRequest() { OperatorName = "Oper3" };
            var req2 = new SupportRequest() { OperatorName = "Oper3" };
            var req3 = new SupportRequest() { OperatorName = "Oper3" };
            context.SupportRequests.Add(req);
            context.SupportRequests.Add(req1);
            context.SupportRequests.Add(req2);
            context.SupportRequests.Add(req3);


            base.Seed(context);
        }
    }
}