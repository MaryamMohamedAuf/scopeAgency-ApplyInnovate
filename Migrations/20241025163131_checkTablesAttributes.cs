using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scopeAgency.Migrations
{
    /// <inheritdoc />
    public partial class checkTablesAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoiceDetails_units_unitNo",
                table: "invoiceDetails");

            migrationBuilder.AlterColumn<int>(
                name: "unitNo",
                table: "invoiceDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_invoiceDetails_units_unitNo",
                table: "invoiceDetails",
                column: "unitNo",
                principalTable: "units",
                principalColumn: "unitNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoiceDetails_units_unitNo",
                table: "invoiceDetails");

            migrationBuilder.AlterColumn<int>(
                name: "unitNo",
                table: "invoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_invoiceDetails_units_unitNo",
                table: "invoiceDetails",
                column: "unitNo",
                principalTable: "units",
                principalColumn: "unitNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
