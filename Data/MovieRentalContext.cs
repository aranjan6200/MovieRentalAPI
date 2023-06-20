using Microsoft.EntityFrameworkCore;
using MovieRentalApplication.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MovieRentalApplication.Data
{
    public class MovieRentalContext : DbContext
    {
        public MovieRentalContext(DbContextOptions<MovieRentalContext> options)
        : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalDetail> RentalDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the mappings using Fluent API methods

            // Example:
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure other relationships and entity mappings as needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
