using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class header : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Food",
                table: "Causes");

            migrationBuilder.RenameColumn(
                name: "Water",
                table: "Causes",
                newName: "Header");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Header",
                table: "Causes",
                newName: "Water");

            migrationBuilder.AddColumn<string>(
                name: "Food",
                table: "Causes",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
