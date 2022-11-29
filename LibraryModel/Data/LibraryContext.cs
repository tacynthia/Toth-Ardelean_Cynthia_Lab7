﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using Toth_Ardelean_Cynthia_Lab2.Models;

namespace Toth_Ardelean_Cynthia_Lab2.Data
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Publisher>? Publishers { get; set; }
        public DbSet<PublishedBook>? PublishedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<PublishedBook>().ToTable("PublishedBook");
            modelBuilder.Entity<PublishedBook>().HasKey(c => new {c.BookID,c.PublisherID}); //configureaza cheia primara compusa

        }

        public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>
        {
            public LibraryContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
                optionsBuilder.UseSqlServer("NewLibraryConnection");
                return new LibraryContext(optionsBuilder.Options);
            }
        }
    }
}

