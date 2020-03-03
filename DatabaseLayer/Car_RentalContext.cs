using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Car_Rental.Models;

namespace Car_Rental.Models
{
    //This class is responsible for connecting to the database and maps table data to entity model classes
    public class Car_RentalContext : DbContext
    {
        public Car_RentalContext (DbContextOptions<Car_RentalContext> options)
            : base(options)
        {
        }

        public DbSet<Car_Rental.Models.Car> Car { get; set; }

        public DbSet<Car_Rental.Models.User> User { get; set; }

        public DbSet<Car_Rental.Models.Booking> Booking { get; set; }

        public DbSet<Car_Rental.Models.Driver> Driver { get; set; }

        protected internal virtual void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Driver>().HasOne(d => d.Car).WithOne(c => c.Driver)
                .OnDelete(DeleteBehavior.SetNull);
                   





        }


    }
}
