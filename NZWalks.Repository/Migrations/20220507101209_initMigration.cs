using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NZWalks.Repository.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Information");

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "Information",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Long = table.Column<double>(type: "float", nullable: false),
                    Population = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalkDifficulty",
                schema: "Information",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 30, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkDifficulty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Walks",
                schema: "Information",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    WalkDifficultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Walks_Regions",
                        column: x => x.RegionId,
                        principalSchema: "Information",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Walks_WalkDifficulty",
                        column: x => x.WalkDifficultyId,
                        principalSchema: "Information",
                        principalTable: "WalkDifficulty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionId",
                schema: "Information",
                table: "Walks",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_WalkDifficultyId",
                schema: "Information",
                table: "Walks",
                column: "WalkDifficultyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Walks",
                schema: "Information");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "Information");

            migrationBuilder.DropTable(
                name: "WalkDifficulty",
                schema: "Information");
        }
    }
}
