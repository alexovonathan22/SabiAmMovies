﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SabiAmMovies.WebAPI.Infrastructure.Persistence;

namespace SabiAmMovies.WebAPI.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("SabiAmMovies.WebAPI.Domain.DataModels.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CurrencyUnit")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Genre")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MaxAge")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<string>("YearOfRelease")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("SabiAmMovies.WebAPI.Domain.DataModels.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("AuthToken")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsEmailConfirm")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("OTP")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("longblob");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2021, 6, 24, 18, 51, 34, 196, DateTimeKind.Local).AddTicks(9625),
                            Email = "avo.nathan@gmail.com",
                            IsActive = false,
                            IsDeleted = false,
                            IsEmailConfirm = true,
                            Name = "adminovo",
                            PasswordHash = new byte[] { 235, 145, 240, 204, 235, 250, 107, 89, 169, 111, 17, 192, 46, 107, 129, 109, 177, 48, 211, 154, 0, 83, 6, 82, 245, 31, 54, 176, 42, 160, 149, 250, 40, 122, 109, 174, 151, 31, 196, 37, 130, 124, 122, 180, 135, 7, 73, 25, 63, 239, 12, 141, 92, 224, 210, 218, 157, 202, 193, 239, 126, 233, 216, 91 },
                            PasswordSalt = new byte[] { 125, 21, 39, 109, 49, 62, 3, 156, 185, 121, 174, 40, 184, 23, 52, 242, 9, 120, 129, 155, 6, 229, 144, 58, 61, 111, 44, 99, 54, 18, 82, 115, 102, 213, 195, 96, 152, 4, 65, 76, 199, 102, 91, 76, 129, 166, 17, 28, 71, 213, 253, 162, 177, 139, 43, 79, 103, 82, 209, 218, 110, 118, 134, 102, 53, 132, 164, 90, 4, 117, 74, 92, 152, 222, 202, 140, 240, 172, 119, 40, 63, 141, 132, 195, 82, 230, 173, 40, 200, 218, 125, 14, 59, 92, 185, 61, 147, 104, 47, 196, 125, 208, 218, 12, 72, 151, 155, 91, 129, 150, 84, 102, 14, 151, 29, 154, 50, 124, 70, 117, 31, 153, 234, 158, 87, 129, 158, 151 },
                            Role = "AppAdmin"
                        });
                });

            modelBuilder.Entity("SabiAmMovies.WebAPI.Domain.DataModels.RentalOrder", b =>
                {
                    b.HasBaseType("SabiAmMovies.WebAPI.Domain.DataModels.Movie");

                    b.Property<decimal>("CalculatedPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("DaysRented")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.ToTable("RentalOrders");
                });

            modelBuilder.Entity("SabiAmMovies.WebAPI.Domain.DataModels.RentalOrder", b =>
                {
                    b.HasOne("SabiAmMovies.WebAPI.Domain.DataModels.Movie", null)
                        .WithOne()
                        .HasForeignKey("SabiAmMovies.WebAPI.Domain.DataModels.RentalOrder", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
