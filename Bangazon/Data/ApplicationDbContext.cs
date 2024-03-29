﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Bangazon.Interfaces;
using Bangazon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Order>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            // Restrict deletion of related order when OrderProducts entry is removed
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderProducts)
                .WithOne(l => l.Order)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            

            // Restrict deletion of related product when OrderProducts entry is removed
            modelBuilder.Entity<Product>()
                .HasMany(o => o.OrderProducts)
                .WithOne(l => l.Product)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PaymentType>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Admina",
                LastName = "Straytor",
                StreetAddress = "123 Infinity Way",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<PaymentType>().HasData(
                new PaymentType()
                {
                    PaymentTypeId = 1,
                    UserId = user.Id,
                    Description = "American Express",
                    AccountNumber = "86753095551212"
                },
                new PaymentType()
                {
                    PaymentTypeId = 2,
                    UserId = user.Id,
                    Description = "Discover",
                    AccountNumber = "4102948572991"
                }
            );

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType()
                {
                    ProductTypeId = 1,
                    Label = "Sporting Goods"
                },
                new ProductType()
                {
                    ProductTypeId = 2,
                    Label = "Appliances"
                },
                new ProductType()
                {
                    ProductTypeId = 3,
                    Label = "Tools"
                },
                new ProductType()
                {
                    ProductTypeId = 4,
                    Label = "Games"
                },
                new ProductType()
                {
                    ProductTypeId = 5,
                    Label = "Music"
                },
                new ProductType()
                {
                    ProductTypeId = 6,
                    Label = "Health"
                },
                new ProductType()
                {
                    ProductTypeId = 7,
                    Label = "Outdoors"
                },
                new ProductType()
                {
                    ProductTypeId = 8,
                    Label = "Beauty"
                },
                new ProductType()
                {
                    ProductTypeId = 9,
                    Label = "Shoes"
                },
                new ProductType()
                {
                    ProductTypeId = 10,
                    Label = "Automotive"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    ProductTypeId = 1,
                    UserId = user.Id,
                    Description = "It flies high",
                    Title = "Kite",
                    Quantity = 100,
                    Price = 2.99
                },
                new Product()
                {
                    ProductId = 2,
                    ProductTypeId = 2,
                    UserId = user.Id,
                    Description = "It rolls fast",
                    Title = "Wheelbarrow",
                    Quantity = 5,
                    Price = 29.99
                },
                new Product()
                {
                    ProductId = 3,
                    ProductTypeId = 3,
                    UserId = user.Id,
                    Description = "It cuts things",
                    Title = "Saw",
                    Quantity = 18,
                    Price = 31.49
                },
                new Product()
                {
                    ProductId = 4,
                    ProductTypeId = 3,
                    UserId = user.Id,
                    Description = "It puts holes in things",
                    Title = "Electric Drill",
                    Quantity = 12,
                    Price = 24.89
                },
                new Product()
                {
                    ProductId = 5,
                    ProductTypeId = 3,
                    UserId = user.Id,
                    Description = "It puts things together",
                    Title = "Hammer",
                    Quantity = 32,
                    Price = 22.69
                },
                 new Product()
                 {
                     ProductId = 6,
                     ProductTypeId = 3,
                     UserId = user.Id,
                     Description = "It puts things together",
                     Title = "Wrench",
                     Quantity = 32,
                     Price = 21.69
                 }, new Product()
                 {
                     ProductId = 7,
                     ProductTypeId = 1,
                     UserId = user.Id,
                     Description = "Get on the river",
                     Title = "Canoe",
                     Quantity = 30,
                     Price = 249.99
                 },
                 new Product()
                 {
                     ProductId = 8,
                     ProductTypeId = 1,
                     UserId = user.Id,
                     Description = "21 Speed Mountain bike",
                     Title = "Bicycle",
                     Quantity = 50,
                     Price = 499.99
                 },
                 new Product()
                 {
                     ProductId = 9,
                     ProductTypeId = 1,
                     UserId = user.Id,
                     Description = "Catch fish with this",
                     Title = "Fishing Rod",
                     Quantity = 100,
                     Price = 2.99
                 },
                 new Product()
                 {
                     ProductId = 10,
                     ProductTypeId = 2,
                     UserId = user.Id,
                     Description = "Clothes get dry in it",
                     Title = "Dryer",
                     Quantity = 25,
                     Price = 449.99
                 },
                 new Product()
                 {
                     ProductId = 11,
                     ProductTypeId = 2,
                     UserId = user.Id,
                     Description = "Cleans dirty dishes",
                     Title = "Dishwasher",
                     Quantity = 10,
                     Price = 199.99
                 },
                 new Product()
                 {
                     ProductId = 12,
                     ProductTypeId = 2,
                     UserId = user.Id,
                     Description = "Clean your dirty duds",
                     Title = "Washing Maching",
                     Quantity = 10,
                     Price = 299.99
                 },
                 new Product()
                 {
                     ProductId = 13,
                     ProductTypeId = 3,
                     UserId = user.Id,
                     Description = "Smooth rough surfaces, orbitally",
                     Title = "Orbital Sander",
                     Quantity = 50,
                     Price = 39.99
                 },
                 new Product()
                 {
                     ProductId = 14,
                     ProductTypeId = 3,
                     UserId = user.Id,
                     Description = "Unclog a drin with this",
                     Title = "Plunger",
                     Quantity = 100,
                     Price = 2.99
                 },
                 new Product()
                 {
                     ProductId = 15,
                     ProductTypeId = 3,
                     UserId = user.Id,
                     Description = "Jack up your car",
                     Title = "Pump Jack",
                     Quantity = 50,
                     Price = 99.99
                 },
                 new Product()
                 {
                     ProductId = 16,
                     ProductTypeId = 4,
                     UserId = user.Id,
                     Description = "Fun for the whole family",
                     Title = "Monopoly",
                     Quantity = 200,
                     Price = 12.99
                 },
                 new Product()
                 {
                     ProductId = 17,
                     ProductTypeId = 4,
                     UserId = user.Id,
                     Description = "Tie yourself in knots",
                     Title = "Twister",
                     Quantity = 10,
                     Price = 29.99
                 },
                 new Product()
                 {
                     ProductId = 18,
                     ProductTypeId = 4,
                     UserId = user.Id,
                     Description = "Learn words and have fun",
                     Title = "Scrabble",
                     Quantity = 50,
                     Price = 2.99
                 },
                 new Product()
                 {
                     ProductId = 19,
                     ProductTypeId = 5,
                     UserId = user.Id,
                     Description = "88 Keys digital piano",
                     Title = "Keyboard",
                     Quantity = 10,
                     Price = 1099.99
                 },
                 new Product()
                 {
                     ProductId = 20,
                     ProductTypeId = 5,
                     UserId = user.Id,
                     Description = "6 string acoustic",
                     Title = "Guitar",
                     Quantity = 20,
                     Price = 299.99
                 },
                 new Product()
                 {
                     ProductId = 21,
                     ProductTypeId = 5,
                     UserId = user.Id,
                     Description = "Plug in and practice your rhythm",
                     Title = "Electric Drum Set",
                     Quantity = 15,
                     Price = 599.99
                 },
                 new Product()
                 {
                     ProductId = 22,
                     ProductTypeId = 4,
                     UserId = user.Id,
                     Description = "I play",
                     Title = "Dungeon Crawler",
                     Quantity = 3,
                     Price = 10.69
                 }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    OrderId = 1,
                    UserId = user.Id,
                    PaymentTypeId = null
                }
            );

            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct()
                {
                    OrderProductId = 1,
                    OrderId = 1,
                    ProductId = 1
                }
            );

            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct()
                {
                    OrderProductId = 2,
                    OrderId = 1,
                    ProductId = 2
                }
            );
        }
        // Override method for SaveChangesAsync(). The purpose of overriding this method is to be able to Soft Delete resources that implement the IIsDeleted interface. The method still allows resources to be deleted if there are no constraint Database Exceptions thrown. 
        public override async System.Threading.Tasks.Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // The ChangeTracker will start looking through the db context and find which entities have a changed state
            ChangeTracker.DetectChanges();

            // We declare the markedAsDeleted variable which contains all the entities that currently hold the state 'Deleted'
            var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

            // We try to run the SaveChangesAsync() method, which will still delete any entities that are marked as 'Deleted' in the database context. However, if there are any database exceptions due to constraints, it will run the code block within the catch.
            try
            {
                return await base.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // For each entity in the markedAsDeleted variable, we check to make sure that the resource implements the IIsDeleted interface. If so, the entities model state is changed to 'Unchanged' from 'Deleted'. Then, we changed the entity's Active boolean property to false, making the new enitity state 'Modified'. After this, we run the SaveChangesAsync method which finds the 'Modified' entity, and does an Update to the database. This is used to filter out items that the user has 'Deleted', but we still want in the database.
                foreach (var item in markedAsDeleted)
                {
                    if (item.Entity is IIsDeleted entity)
                    {
                        // Set the entity to unchanged (if we mark the whole entity as Modified, every field gets sent to Db as an update)
                        item.State = EntityState.Unchanged;
                        // Only update the IsDeleted flag - only this will get sent to the Db
                        entity.Active = false;
                    }
                }
                return await base.SaveChangesAsync();

            }
        }
    }
}