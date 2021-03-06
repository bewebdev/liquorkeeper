﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LiquorKeeper.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StoreProduct> StoreProducts { get; set; }
        public DbSet<StorePromotion> StorePromotions { get; set; }

    }
}