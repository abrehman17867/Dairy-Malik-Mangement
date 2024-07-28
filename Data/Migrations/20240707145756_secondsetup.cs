using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dairy_Malik_Mangement.Data.Migrations
{
    /// <inheritdoc />
    public partial class secondsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Milk",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Milk",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Milk",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Milk",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Milk",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Liter",
                table: "Milk",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "NearestLocation",
                table: "Milk",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Milk");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Milk");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Milk");

            migrationBuilder.DropColumn(
                name: "Liter",
                table: "Milk");

            migrationBuilder.DropColumn(
                name: "NearestLocation",
                table: "Milk");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Milk",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Milk",
                newName: "quantity");
        }
    }
}
