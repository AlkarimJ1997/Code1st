using System;
using System.Collections.Generic;
using System.Text;
using Code1st.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Code1st.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; } 
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            
            // here is where we can seed the tables with sample data
            modelBuilder.Entity<Team>().HasData(SampleData.GetTeams());
            modelBuilder.Entity<Player>().HasData(SampleData.GetPlayers());
        }
    }
}
