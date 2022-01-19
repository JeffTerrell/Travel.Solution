using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    State = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Country = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Review = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.DestinationId);
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "City", "Country", "Rating", "Review", "State" },
                values: new object[,]
                {
                    { 2, "New York", "United States", 3, "Awesome city to visit!", "New York" },
                    { 3, "Seattle", "United States", 7, "Awesome city to visit!", "Washington" },
                    { 4, "Houston", "United States", 7, "Awesome city to visit!", "Texas" },
                    { 5, "Portland", "United States", 8, "Awesome city to visit!", "Oregon" },
                    { 6, "Boise", "United States", 5, "Awesome city to visit!", "Idaho" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
