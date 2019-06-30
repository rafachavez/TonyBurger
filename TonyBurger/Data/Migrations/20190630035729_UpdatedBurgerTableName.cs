using Microsoft.EntityFrameworkCore.Migrations;

namespace TonyBurger.Data.Migrations
{
    public partial class UpdatedBurgerTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Burgers",
                table: "Burgers");

            migrationBuilder.RenameTable(
                name: "Burgers",
                newName: "Burger");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Burger",
                table: "Burger",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Burger",
                table: "Burger");

            migrationBuilder.RenameTable(
                name: "Burger",
                newName: "Burgers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Burgers",
                table: "Burgers",
                column: "Id");
        }
    }
}
