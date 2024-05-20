using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengerAgroCare.Migrations
{
    /// <inheritdoc />
    public partial class TerceiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabela_Comentario_Grex_1_Tabela_Postagem_Grex_1_PostagemId",
                table: "Tabela_Comentario_Grex_1");

            migrationBuilder.AlterColumn<int>(
                name: "PostagemId",
                table: "Tabela_Comentario_Grex_1",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Tabela_Comentario_Grex_1",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabela_Comentario_Grex_1_Tabela_Postagem_Grex_1_PostagemId",
                table: "Tabela_Comentario_Grex_1",
                column: "PostagemId",
                principalTable: "Tabela_Postagem_Grex_1",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabela_Comentario_Grex_1_Tabela_Postagem_Grex_1_PostagemId",
                table: "Tabela_Comentario_Grex_1");

            migrationBuilder.AlterColumn<int>(
                name: "PostagemId",
                table: "Tabela_Comentario_Grex_1",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Tabela_Comentario_Grex_1",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tabela_Comentario_Grex_1_Tabela_Postagem_Grex_1_PostagemId",
                table: "Tabela_Comentario_Grex_1",
                column: "PostagemId",
                principalTable: "Tabela_Postagem_Grex_1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
