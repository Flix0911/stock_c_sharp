using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// giant class that allows you to search your individual tables

namespace api.Data
// inherit from DbContext
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        // hit ctor ~ create a constructor
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        // make a base
        : base(options)
        {
            // add tables
        }
        // grab something from the db and you need to do something with it
        // manipulating the entire Stock table ~ this will make the db
        
        // Create for Stock
        public DbSet<Stock> Stocks { get; set; }
        // create for Comment
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        // we need roles
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(x => x.HasKey(p => new {p.AppUserId, p.stockId}));

            // connect to table
            builder.Entity<Portfolio>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<Portfolio>()
                .HasOne(u => u.Stock)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.stockId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            // add these new models
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}