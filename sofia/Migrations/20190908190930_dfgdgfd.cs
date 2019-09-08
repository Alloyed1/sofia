using Microsoft.EntityFrameworkCore.Migrations;

namespace sofia.Migrations
{
    public partial class dfgdgfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Predoplata",
                table: "Homes",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Homes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Homes");

            migrationBuilder.AlterColumn<bool>(
                name: "Predoplata",
                table: "Homes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
