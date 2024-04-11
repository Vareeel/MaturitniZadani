using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maturitniZadani.Migrations
{
    public partial class piss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CasPridani",
                table: "Poznamky",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "JeDulezita",
                table: "Poznamky",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CasPridani",
                table: "Poznamky");

            migrationBuilder.DropColumn(
                name: "JeDulezita",
                table: "Poznamky");
        }
    }
}
