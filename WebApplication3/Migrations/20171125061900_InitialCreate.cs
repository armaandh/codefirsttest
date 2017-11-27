using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication3.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    CollegeName = table.Column<string>(nullable: false),
                    Established = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.CollegeName);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingName = table.Column<string>(nullable: false),
                    CollegeName = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => new { x.BuildingName, x.CollegeName });
                    table.ForeignKey(
                        name: "FK_Buildings_Colleges_CollegeName",
                        column: x => x.CollegeName,
                        principalTable: "Colleges",
                        principalColumn: "CollegeName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<string>(nullable: false),
                    BuildingName = table.Column<string>(nullable: false),
                    CollegeName = table.Column<string>(nullable: false),
                    SeatingCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => new { x.RoomID, x.BuildingName, x.CollegeName });
                    table.UniqueConstraint("AK_Rooms_BuildingName_CollegeName_RoomID", x => new { x.BuildingName, x.CollegeName, x.RoomID });
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BuildingName_CollegeName",
                        columns: x => new { x.BuildingName, x.CollegeName },
                        principalTable: "Buildings",
                        principalColumns: new[] { "BuildingName", "CollegeName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CollegeName",
                table: "Buildings",
                column: "CollegeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Colleges");
        }
    }
}
