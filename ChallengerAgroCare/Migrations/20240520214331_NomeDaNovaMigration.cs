using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengerAgroCare.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaNovaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabela_Comentario_Grex_1_Tabela_Usuarios_Grex_1_UserId",
                table: "Tabela_Comentario_Grex_1");

            migrationBuilder.DropForeignKey(
                name: "FK_Tabela_Postagem_Grex_1_Tabela_Usuarios_Grex_1_UserId",
                table: "Tabela_Postagem_Grex_1");

            migrationBuilder.AlterColumn<int>(
                name: "Usuario_Ativo",
                table: "Tabela_Usuarios_Grex_1",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tabela_Postagem_Grex_1",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tabela_Comentario_Grex_1",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "UseId",
                table: "Tabela_Comentario_Grex_1",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabela_Comentario_Grex_1_Tabela_Usuarios_Grex_1_UserId",
                table: "Tabela_Comentario_Grex_1",
                column: "UserId",
                principalTable: "Tabela_Usuarios_Grex_1",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabela_Postagem_Grex_1_Tabela_Usuarios_Grex_1_UserId",
                table: "Tabela_Postagem_Grex_1",
                column: "UserId",
                principalTable: "Tabela_Usuarios_Grex_1",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabela_Comentario_Grex_1_Tabela_Usuarios_Grex_1_UserId",
                table: "Tabela_Comentario_Grex_1");

            migrationBuilder.DropForeignKey(
                name: "FK_Tabela_Postagem_Grex_1_Tabela_Usuarios_Grex_1_UserId",
                table: "Tabela_Postagem_Grex_1");

            migrationBuilder.AlterColumn<bool>(
                name: "Usuario_Ativo",
                table: "Tabela_Usuarios_Grex_1",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tabela_Postagem_Grex_1",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tabela_Comentario_Grex_1",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UseId",
                table: "Tabela_Comentario_Grex_1",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tabela_Comentario_Grex_1_Tabela_Usuarios_Grex_1_UserId",
                table: "Tabela_Comentario_Grex_1",
                column: "UserId",
                principalTable: "Tabela_Usuarios_Grex_1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tabela_Postagem_Grex_1_Tabela_Usuarios_Grex_1_UserId",
                table: "Tabela_Postagem_Grex_1",
                column: "UserId",
                principalTable: "Tabela_Usuarios_Grex_1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
