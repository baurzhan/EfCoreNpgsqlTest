using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

namespace EfCoreNpgsqlTest.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateTimeEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Valid = table.Column<NpgsqlRange<DateTime>>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateTimeEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstantEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Valid = table.Column<NpgsqlRange<Instant>>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstantEntities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateTimeEntities");

            migrationBuilder.DropTable(
                name: "InstantEntities");
        }
    }
}
