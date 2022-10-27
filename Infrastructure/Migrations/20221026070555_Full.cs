using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Full : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Explanation",
                table: "Causes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Goal",
                table: "Causes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Raised",
                table: "Causes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Explanation",
                table: "Causes");

            migrationBuilder.DropColumn(
                name: "Goal",
                table: "Causes");

            migrationBuilder.DropColumn(
                name: "Raised",
                table: "Causes");
        }
    }
}
