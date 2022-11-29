using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toth_Ardelean_Cynthia_Lab2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Author",
            //    columns: table => new
            //    {
            //        AuthorID = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        FirstName = table.Column<string>(type: "text", nullable: true),
            //        LastName = table.Column<string>(type: "text", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Author", x => x.AuthorID);
            //    });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Adress = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PublisherName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorID = table.Column<int>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Author",
                        principalColumn: "AuthorID");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    BookID = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublisedBook",
                columns: table => new
                {
                    PublisherID = table.Column<int>(type: "INTEGER", nullable: false),
                    BookID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisedBook", x => new { x.BookID, x.PublisherID });
                    table.ForeignKey(
                        name: "FK_PublisedBook_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublisedBook_Publisher_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publisher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorID",
                table: "Book",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BookID",
                table: "Order",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_PublisedBook_PublisherID",
                table: "PublisedBook",
                column: "PublisherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PublisedBook");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
