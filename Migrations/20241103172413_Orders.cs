using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maiboroda_Flowers.Migrations
{
    /// <inheritdoc />
    public partial class Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CitySender = table.Column<string>(type: "TEXT", nullable: false),
                    AddressSender = table.Column<string>(type: "TEXT", nullable: false),
                    CityRecipient = table.Column<string>(type: "TEXT", nullable: false),
                    AddressRecipient = table.Column<string>(type: "TEXT", nullable: false),
                    ProductWeight = table.Column<double>(type: "NUMERIC", nullable: false),
                    DateReceipt = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id",
                table: "Orders",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
