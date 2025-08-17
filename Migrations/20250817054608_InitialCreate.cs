using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hero_api_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    sex = table.Column<string>(type: "TEXT", nullable: false),
                    abilities = table.Column<string>(type: "TEXT", maxLength: 400, nullable: false),
                    superpower = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_heroes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "heroes");
        }
    }
}
