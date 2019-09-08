using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sofia.Migrations
{
    public partial class fdghfghf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeSdelki = table.Column<int>(nullable: false),
                    TypeArenda = table.Column<int>(nullable: false),
                    TypeCommerce = table.Column<int>(nullable: false),
                    ObjectText = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Coords = table.Column<string>(nullable: true),
                    Comnat = table.Column<int>(nullable: false),
                    PloshadRoom = table.Column<double>(nullable: false),
                    AllPloshadRoom = table.Column<double>(nullable: false),
                    AllCountRoom = table.Column<int>(nullable: false),
                    Kuxnya = table.Column<double>(nullable: false),
                    Balkon = table.Column<string>(nullable: true),
                    SanUzelRazdel = table.Column<string>(nullable: true),
                    SanUzelVmeste = table.Column<string>(nullable: true),
                    Remont = table.Column<string>(nullable: true),
                    Animals = table.Column<bool>(nullable: false),
                    Children = table.Column<bool>(nullable: false),
                    ZdanieName = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    HeightPotolok = table.Column<double>(nullable: false),
                    Parkovka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    HomeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dops_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dops_HomeId",
                table: "Dops",
                column: "HomeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dops");

            migrationBuilder.DropTable(
                name: "Homes");
        }
    }
}
