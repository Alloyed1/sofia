using Microsoft.EntityFrameworkCore.Migrations;

namespace sofia.Migrations
{
    public partial class dfdsfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Homes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Homes");
        }
    }
}
