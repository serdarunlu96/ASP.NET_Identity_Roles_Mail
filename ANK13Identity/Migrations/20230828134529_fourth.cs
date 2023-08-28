using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANK13Identity.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentLessons_AspNetUsers_UserId",
                table: "StudentLessons");

            migrationBuilder.DropIndex(
                name: "IX_StudentLessons_UserId",
                table: "StudentLessons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StudentLessons");

            migrationBuilder.AlterColumn<string>(
                name: "ANK13IdentityUserId",
                table: "StudentLessons",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLessons_ANK13IdentityUserId",
                table: "StudentLessons",
                column: "ANK13IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLessons_AspNetUsers_ANK13IdentityUserId",
                table: "StudentLessons",
                column: "ANK13IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentLessons_AspNetUsers_ANK13IdentityUserId",
                table: "StudentLessons");

            migrationBuilder.DropIndex(
                name: "IX_StudentLessons_ANK13IdentityUserId",
                table: "StudentLessons");

            migrationBuilder.AlterColumn<int>(
                name: "ANK13IdentityUserId",
                table: "StudentLessons",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "StudentLessons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentLessons_UserId",
                table: "StudentLessons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLessons_AspNetUsers_UserId",
                table: "StudentLessons",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
