using Microsoft.EntityFrameworkCore.Migrations;

namespace sofia.Migrations
{
    public partial class dfghfsdghr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Communal",
                table: "Homes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Etag",
                table: "Homes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EtagAll",
                table: "Homes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Homes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Predoplata",
                table: "Homes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Sostav",
                table: "Homes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Zalog",
                table: "Homes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Communal",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Etag",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "EtagAll",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Predoplata",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Sostav",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Zalog",
                table: "Homes");
        }
    }
}
