using Microsoft.EntityFrameworkCore.Migrations;

namespace Soundbox.Migrations
{
    public partial class ArtistChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Artist",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Artist",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NetWorth",
                table: "Artist",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Artist",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Retired",
                table: "Artist",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "NetWorth",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "Retired",
                table: "Artist");
        }
    }
}
