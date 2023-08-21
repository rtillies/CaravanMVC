using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaravanMVC.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "wagons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    num_wheels = table.Column<int>(type: "integer", nullable: false),
                    is_covered = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wagons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    destination = table.Column<string>(type: "text", nullable: false),
                    wagon_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_passengers", x => x.id);
                    table.ForeignKey(
                        name: "fk_passengers_wagons_wagon_id",
                        column: x => x.wagon_id,
                        principalTable: "wagons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "wagons",
                columns: new[] { "id", "is_covered", "name", "num_wheels" },
                values: new object[,]
                {
                    { 1, true, "Lexi Silver", 4 },
                    { 2, false, "Clifford", 4 }
                });

            migrationBuilder.InsertData(
                table: "passengers",
                columns: new[] { "id", "age", "destination", "name", "wagon_id" },
                values: new object[,]
                {
                    { 1, 28, "Virginia", "Professor", 1 },
                    { 2, 22, "North Carolina", "Bella", 2 },
                    { 3, 28, "Virginia", "Seneca", 1 },
                    { 4, 35, "Virginia", "Carolyn", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_passengers_wagon_id",
                table: "passengers",
                column: "wagon_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passengers");

            migrationBuilder.DropTable(
                name: "wagons");
        }
    }
}
