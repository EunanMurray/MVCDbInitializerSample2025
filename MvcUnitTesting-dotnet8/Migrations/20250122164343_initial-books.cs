using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MvcUnitTesting_dotnet8.Migrations
{
    /// <inheritdoc />
    public partial class initialbooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Genre", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Fiction", "Moby Dick", 12.50m },
                    { 2, "Fiction", "War and Peace", 17m },
                    { 3, "Science Fiction", "Escape from the vortex", 12.50m },
                    { 4, "History", "The Battle of the Somme", 22m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
