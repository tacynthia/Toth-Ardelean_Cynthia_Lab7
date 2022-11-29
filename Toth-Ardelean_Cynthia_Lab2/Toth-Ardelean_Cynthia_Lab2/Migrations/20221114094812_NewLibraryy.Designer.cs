﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Toth_Ardelean_Cynthia_Lab2.Data;

#nullable disable

namespace Toth_Ardelean_Cynthia_Lab2.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20221114094812_NewLibraryy")]
    partial class NewLibraryy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Toth_Ardelean_Cynthia_Lab2.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AuthorID");

                    b.ToTable("Author", (string)null);
                });

            modelBuilder.Entity("Toth_Ardelean_Cynthia_Lab2.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("Toth_Ardelean_Cynthia_Lab2.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Toth_Ardelean_Cynthia_Lab2.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderID");

                    b.HasIndex("BookID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Toth_Ardelean_Cynthia_Lab2.Models.PublishedBook", b =>
                {
                    b.Property<int?>("BookID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PublisherID")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookID", "PublisherID");

                    b.HasIndex("PublisherID");

                    b.ToTable("PublisedBook", (string)null);
                });

            modelBuilder.Entity("Toth_Ardelean_Cynthia_Lab2.Models.Publisher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("TEXT");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Publisher", (string)null);
                });

            modelBuilder.Entity("Toth_Ardelean_Cynthia_Lab2.Models.Book", b =>
                {
                    b.HasOne("Toth_Ardelean_Cynthia_Lab2.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Toth_Ardelean_Cynthia_Lab2.Models.Order", b =>
                {
                    b.HasOne("Toth_Ardelean_Cynthia_Lab2.Models.Book", "Book")
                        .WithMany("Orders")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Toth_Ardelean_Cynthia_Lab2.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Toth_Ardelean_Cynthia_Lab2.Models.PublishedBook", b =>
                {
                    b.HasOne("Toth_Ardelean_Cynthia_Lab2.Models.Book", "Book")
                        .WithMany("PublishedBooks")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Toth_Ardelean_Cynthia_Lab2.Models.Publisher", "Publisher")
                        .WithMany("PublishedBooks")
                        .HasForeignKey("PublisherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Toth_Ardelean_Cynthia_Lab2.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Toth_Ardelean_Cynthia_Lab2.Models.Book", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("PublishedBooks");
                });

            modelBuilder.Entity("Toth_Ardelean_Cynthia_Lab2.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Toth_Ardelean_Cynthia_Lab2.Models.Publisher", b =>
                {
                    b.Navigation("PublishedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
