using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookLibrary.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "book_id", "category", "copies_in_use", "first_name", "isbn", "last_name", "title", "total_copies", "type" },
                values: new object[,]
                {
                    { 2, "Paperback", 65, "Harper", "1234567892", "Lee", "To Kill a Mockingbird", 75, "Fiction" },
                    { 3, "Hardcover", 45, "J.D.", "1234567893", "Salinger", "The Catcher in the Rye", 50, "Fiction" },
                    { 4, "Hardcover", 22, "F. Scott", "1234567894", "Fitzgerald", "The Great Gatsby", 50, "'Non-Fiction" },
                    { 5, "Hardcover", 35, "Paulo", "1234567895", "Coelho", "The Alchemist", 50, "'Biography" },
                    { 6, "Hardcover", 11, "Markus", "1234567896", "Zusak", "The Book Thief", 75, "'Mystery" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 6);
        }
    }
}
