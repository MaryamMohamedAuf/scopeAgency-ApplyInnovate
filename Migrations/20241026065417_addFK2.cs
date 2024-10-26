using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scopeAgency.Migrations
{
    /// <inheritdoc />
    public partial class addFK2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoiceDetails_units_unitNo1",
                table: "invoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_invoiceDetails_unitNo1",
                table: "invoiceDetails");

            migrationBuilder.DropColumn(
                name: "unitNo1",
                table: "invoiceDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "unitNo1",
                table: "invoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoiceDetails_unitNo1",
                table: "invoiceDetails",
                column: "unitNo1");

            migrationBuilder.AddForeignKey(
                name: "FK_invoiceDetails_units_unitNo1",
                table: "invoiceDetails",
                column: "unitNo1",
                principalTable: "units",
                principalColumn: "unitNo");
        }
    }
}
