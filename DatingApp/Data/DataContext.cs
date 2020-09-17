using DatingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DatingApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DatingAppDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        }


        public DbSet<Values> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }    
}