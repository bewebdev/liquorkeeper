namespace LiquorKeeper.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LiquorKeeper.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<LiquorKeeper.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LiquorKeeper.Models.ApplicationDbContext context)
        {
            //create our test user
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser();
            user.UserName = "EvansLiquor";
            var adminresult = UserManager.Create(user, "password");

            //get this user from the database
            var GetUser = context.Users.Where(x => x.UserName.Equals("EvansLiquor")).FirstOrDefault();

            //now lets add a store for them
            //stripped down currently
            context.Stores.AddOrUpdate(new Store { Name = "Evans Liquor Store", City = "Ham Lake", User = GetUser });

            //TODO: Add in products - we should have a method call for this, so that is can he dropped and added easily

            //TODD: Add products to the test store

            base.Seed(context);
        }
    }
}
