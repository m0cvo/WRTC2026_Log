using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WRTC2026_Log.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logbook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Frequency = table.Column<float>(type: "real", nullable: false),
                    Mode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Callsign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportSent = table.Column<int>(type: "int", nullable: false),
                    ReportReceived = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logbook", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logbook");
        }
    }
}
