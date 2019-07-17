using Microsoft.EntityFrameworkCore.Migrations;

namespace Bangazon.Migrations
{
    public partial class addproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "58926cf1-1252-4126-9d9f-10325e8e93b1", "AQAAAAEAACcQAAAAEI2rfIodGoVYR4KP8DDQx8gs4DF5kWsx3Q6tSo3mK533YUiXv4iL2/KSvXQ5D5yzIA==" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Active", "City", "Description", "ImagePath", "Price", "ProductTypeId", "Quantity", "Title", "UserId" },
                values: new object[] { 6, true, null, "It puts things together", null, 21.690000000000001, 3, 32, "Wrench", "00000000-ffff-ffff-ffff-ffffffffffff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cf8a5e66-b274-4347-b5e8-968afd7f3924", "AQAAAAEAACcQAAAAEKBBTiEY64T0PNqiXy1Jiar+rjAGx6cEQkKS15RGjGRaMDo7WIfvg7pO5Vxkm8EMgA==" });
        }
    }
}
