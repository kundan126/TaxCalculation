using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxCalculationDataAPI.Migrations
{
    public partial class TaxMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "TaxId", "Date", "MunicipalityName", "TaxRate" },
                values: new object[] { 2, "2016.07.10", "Copenhagen", 0.2 });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "TaxId", "Date", "MunicipalityName", "TaxRate" },
                values: new object[] { 3, "2016.05.02", "Copenhagen", 0.4 });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "TaxId", "Date", "MunicipalityName", "TaxRate" },
                values: new object[] { 4, "2016.01.01", "Copenhagen", 0.1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: 4);
        }
    }
}
