using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupProject3.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Residents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AcctOwner = table.Column<string>(nullable: true),
                    UnitNum = table.Column<string>(nullable: true),
                    LastName1 = table.Column<string>(nullable: true),
                    FirstName1 = table.Column<string>(nullable: true),
                    StorageNum = table.Column<string>(nullable: true),
                    ContactNum1 = table.Column<string>(nullable: true),
                    ContactNum2 = table.Column<string>(nullable: true),
                    ContactNum3 = table.Column<string>(nullable: true),
                    Email1 = table.Column<string>(nullable: true),
                    Email2 = table.Column<string>(nullable: true),
                    Email3 = table.Column<string>(nullable: true),
                    Email4 = table.Column<string>(nullable: true),
                    ParkingSpot1 = table.Column<string>(nullable: true),
                    ParkingSpot2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residents", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Residents");
        }
    }
}
