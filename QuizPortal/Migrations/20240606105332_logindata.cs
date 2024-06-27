using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizPortal.Migrations
{
    /// <inheritdoc />
    public partial class logindata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "loginSignUp",
                columns: new[] { "User_Id", "Email", "Password", "Role", "UserName" },
                values: new object[] { 1, "vikramkarel@gmail.com", "VK", "SuperAdmin", "Vikram" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "loginSignUp",
                keyColumn: "User_Id",
                keyValue: 1);
        }
    }
}
