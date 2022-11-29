using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toth_Ardelean_Cynthia_Lab2.Migrations
{
    public partial class NewLibraryyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublisedBook_Book_BookID",
                table: "PublisedBook");

            migrationBuilder.DropForeignKey(
                name: "FK_PublisedBook_Publisher_PublisherID",
                table: "PublisedBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublisedBook",
                table: "PublisedBook");

            migrationBuilder.RenameTable(
                name: "PublisedBook",
                newName: "PublishedBook");

            migrationBuilder.RenameIndex(
                name: "IX_PublisedBook_PublisherID",
                table: "PublishedBook",
                newName: "IX_PublishedBook_PublisherID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublishedBook",
                table: "PublishedBook",
                columns: new[] { "BookID", "PublisherID" });

            migrationBuilder.AddForeignKey(
                name: "FK_PublishedBook_Book_BookID",
                table: "PublishedBook",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublishedBook_Publisher_PublisherID",
                table: "PublishedBook",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublishedBook_Book_BookID",
                table: "PublishedBook");

            migrationBuilder.DropForeignKey(
                name: "FK_PublishedBook_Publisher_PublisherID",
                table: "PublishedBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublishedBook",
                table: "PublishedBook");

            migrationBuilder.RenameTable(
                name: "PublishedBook",
                newName: "PublisedBook");

            migrationBuilder.RenameIndex(
                name: "IX_PublishedBook_PublisherID",
                table: "PublisedBook",
                newName: "IX_PublisedBook_PublisherID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublisedBook",
                table: "PublisedBook",
                columns: new[] { "BookID", "PublisherID" });

            migrationBuilder.AddForeignKey(
                name: "FK_PublisedBook_Book_BookID",
                table: "PublisedBook",
                column: "BookID",
                principalTable: "Book",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublisedBook_Publisher_PublisherID",
                table: "PublisedBook",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
