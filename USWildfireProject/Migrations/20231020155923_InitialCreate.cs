using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USWildfireProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wildfires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    DiscoverDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DiscoveryDayOfYear = table.Column<int>(type: "INTEGER", nullable: false),
                    DiscoverTime = table.Column<TimeOnly>(type: "TEXT", nullable: true),
                    CauseClassification = table.Column<string>(type: "TEXT", nullable: true),
                    GeneralCause = table.Column<string>(type: "TEXT", nullable: true),
                    CauseAgeCategory = table.Column<string>(type: "TEXT", nullable: true),
                    ContainmentDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    ContainmentDayOfYear = table.Column<int>(type: "INTEGER", nullable: true),
                    ContainmentTime = table.Column<TimeOnly>(type: "TEXT", nullable: true),
                    Size = table.Column<double>(type: "REAL", nullable: false),
                    SizeClass = table.Column<char>(type: "TEXT", nullable: false),
                    Latitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    Longitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    County = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wildfires", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wildfires");
        }
    }
}
