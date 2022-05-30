using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class atualizacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumAssento",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "TipoIngresso",
                table: "Sessao");

            migrationBuilder.RenameColumn(
                name: "TipoIngresso",
                table: "Ingresso",
                newName: "TipoIngressoId");

            migrationBuilder.AddColumn<int>(
                name: "AssentoId",
                table: "Ingresso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Assento",
                columns: table => new
                {
                    AssentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumAssento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assento", x => x.AssentoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoIngresso",
                columns: table => new
                {
                    TipoIngressoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIngresso = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIngresso", x => x.TipoIngressoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_AssentoId",
                table: "Ingresso",
                column: "AssentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_TipoIngressoId",
                table: "Ingresso",
                column: "TipoIngressoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Assento_AssentoId",
                table: "Ingresso",
                column: "AssentoId",
                principalTable: "Assento",
                principalColumn: "AssentoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_TipoIngresso_TipoIngressoId",
                table: "Ingresso",
                column: "TipoIngressoId",
                principalTable: "TipoIngresso",
                principalColumn: "TipoIngressoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Assento_AssentoId",
                table: "Ingresso");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_TipoIngresso_TipoIngressoId",
                table: "Ingresso");

            migrationBuilder.DropTable(
                name: "Assento");

            migrationBuilder.DropTable(
                name: "TipoIngresso");

            migrationBuilder.DropIndex(
                name: "IX_Ingresso_AssentoId",
                table: "Ingresso");

            migrationBuilder.DropIndex(
                name: "IX_Ingresso_TipoIngressoId",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "AssentoId",
                table: "Ingresso");

            migrationBuilder.RenameColumn(
                name: "TipoIngressoId",
                table: "Ingresso",
                newName: "TipoIngresso");

            migrationBuilder.AddColumn<int>(
                name: "NumAssento",
                table: "Sessao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TipoIngresso",
                table: "Sessao",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");
        }
    }
}
