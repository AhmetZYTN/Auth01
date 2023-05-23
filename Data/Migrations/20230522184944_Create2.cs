using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth01.Data.Migrations
{
    public partial class Create2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "FAQModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategorysId",
                table: "FAQModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FAQCat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQCat", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FAQModel_CategorysId",
                table: "FAQModel",
                column: "CategorysId");

            migrationBuilder.AddForeignKey(
                name: "FK_FAQModel_FAQCat_CategorysId",
                table: "FAQModel",
                column: "CategorysId",
                principalTable: "FAQCat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FAQModel_FAQCat_CategorysId",
                table: "FAQModel");

            migrationBuilder.DropTable(
                name: "FAQCat");

            migrationBuilder.DropIndex(
                name: "IX_FAQModel_CategorysId",
                table: "FAQModel");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "FAQModel");

            migrationBuilder.DropColumn(
                name: "CategorysId",
                table: "FAQModel");
        }
    }
}
