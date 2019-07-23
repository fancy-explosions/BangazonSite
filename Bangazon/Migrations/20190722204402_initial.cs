using Microsoft.EntityFrameworkCore.Migrations;

namespace Bangazon.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b730110-e89e-477c-8faf-1a14a7ab6779", "AQAAAAEAACcQAAAAECNfIR8w65frgUnw1mNSVftU4xh6JMpCxSqn28htwKvNh5UfoPH51nDbcTDPYST/eA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7302ac71-7b15-43ce-a745-633d494588fc", "AQAAAAEAACcQAAAAEC4nz0ptqERZof9x1037MTMbo1clHIMWHwZApkQBqaR1r82ilCKHni1aY1aMqA/Vaw==" });
        }
    }
}
