using Microsoft.EntityFrameworkCore;
using SabiAmMovies.WebAPI.Domain.Constants;
using SabiAmMovies.WebAPI.Domain.DataModels;
using SabiAmMovies.WebAPI.Domain.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace SabiAmMovies.WebAPI.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RentalOrder> RentalOrders { get; set; }
        public DbSet<Movie> Movies { get; set; }



        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //custom logic
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<RentalOrder>().ToTable("RentalOrders");

            var pwd = "01234Admin";
            AuthUtil.CreatePasswordHash(pwd, out byte[] passwordHash, out byte[] passwordSalt);

            //User
            modelBuilder.Entity<User>()
                .HasData(
                   new User
                   {
                       Id = 1,
                       Name = "adminovo",
                       CreatedAt = DateTime.Now,
                       Email = "avo.nathan@gmail.com",
                       Role = UserConstants.Admin,
                       PasswordHash = passwordHash,
                       PasswordSalt = passwordSalt,
                       IsEmailConfirm = true
                   }
            );

        }
    }
}
