using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Sessao");

            migrationBuilder.AddColumn<int>(
                name: "HoraId",
                table: "Ingresso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoIngresso",
                table: "Ingresso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_HoraId",
                table: "Ingresso",
                column: "HoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Hora_HoraId",
                table: "Ingresso",
                column: "HoraId",
                principalTable: "Hora",
                principalColumn: "HoraId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Hora_HoraId",
                table: "Ingresso");

            migrationBuilder.DropIndex(
                name: "IX_Ingresso_HoraId",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "HoraId",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "TipoIngresso",
                table: "Ingresso");

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                table: "Sessao",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }
    }
}
