using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_standings
{
    internal class F1Context : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public F1Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=F1.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().HasData(
            new Driver() { Id = 1, driverId = "albon", givenName = "Alexander", familyName = "Albon", dateOfBirth = "1996-03-23", nationality = "Thai" },
            new Driver() { Id = 2, driverId = "bottas", givenName = "Valtteri", familyName = "Bottas", dateOfBirth = "1989-08-28", nationality = "Finnish" },
            new Driver() { Id = 3, driverId = "raikkonen", givenName = "Kimi", familyName = "Räikkönen", dateOfBirth = "1979-10-17", nationality = "Finnish" }
            );
        }
    }

}
