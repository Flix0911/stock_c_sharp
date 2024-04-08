using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

// giant class that allows you to search your individual tables

namespace api.Data
// inherit from DbContext
{
    public class ApplicationDBContext : DbContext
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
        public DbSet<Stock> Stock { get; set; }
        // create for Comment
        public DbSet<Comment> Comments { get; set; }
    }
}