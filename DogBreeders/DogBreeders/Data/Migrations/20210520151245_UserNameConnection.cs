using Microsoft.EntityFrameworkCore.Migrations;

namespace DogBreeders.Data.Migrations
{
    public partial class UserNameConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserNameId",
                table: "DogBreeders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNameId",
                table: "DogBreeders");
        }
    }
}
