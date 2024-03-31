using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace F1_standings.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    driverId = table.Column<string>(type: "TEXT", nullable: false),
                    url = table.Column<string>(type: "TEXT", nullable: true),
                    givenName = table.Column<string>(type: "TEXT", nullable: false),
                    familyName = table.Column<string>(type: "TEXT", nullable: true),
                    dateOfBirth = table.Column<string>(type: "TEXT", nullable: true),
                    nationality = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "dateOfBirth", "driverId", "familyName", "givenName", "nationality", "url" },
                values: new object[,]
                {
                    { 1, "1996-03-23", "albon", "Albon", "Alexander", "Thai", null },
                    { 2, "1989-08-28", "bottas", "Bottas", "Valtteri", "Finnish", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
