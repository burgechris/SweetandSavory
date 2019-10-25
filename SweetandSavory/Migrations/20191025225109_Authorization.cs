using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetandSavory.Migrations
{
    public partial class Authorization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Treat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Flavor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treat_UserId",
                table: "Treat",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flavor_UserId",
                table: "Flavor",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flavor_AspNetUsers_UserId",
                table: "Flavor",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treat_AspNetUsers_UserId",
                table: "Treat",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flavor_AspNetUsers_UserId",
                table: "Flavor");

            migrationBuilder.DropForeignKey(
                name: "FK_Treat_AspNetUsers_UserId",
                table: "Treat");

            migrationBuilder.DropIndex(
                name: "IX_Treat_UserId",
                table: "Treat");

            migrationBuilder.DropIndex(
                name: "IX_Flavor_UserId",
                table: "Flavor");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Treat");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Flavor");
        }
    }
}
