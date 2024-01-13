using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApp.Migrations
{
    public partial class AddOrdertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoursePrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseBuyerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseBuyerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
