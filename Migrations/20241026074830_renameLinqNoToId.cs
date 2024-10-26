using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scopeAgency.Migrations
{
    /// <inheritdoc />
    public partial class renameLinqNoToId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "linqNo",
                table: "invoiceDetails",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "invoiceDetails",
                newName: "linqNo");
        }
    }
}
