using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maturitniZadani.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poznamky",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajitelId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nadpis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obsah = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poznamky", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uzivatele",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jmeno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Heslo_hashed = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzivatele", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poznamky");

            migrationBuilder.DropTable(
                name: "Uzivatele");
        }
    }
}
