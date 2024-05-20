using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengerAgroCare.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tabela_Usuarios_Grex_1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome_Do_Usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Avatar_Do_Usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha_Do_Usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email_Do_Usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_Do_Cadastro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Usuario_Ativo = table.Column<int>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela_Usuarios_Grex_1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tabela_Postagem_Grex_1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Like = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Texto_Postagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_Do_Post = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela_Postagem_Grex_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tabela_Postagem_Grex_1_Tabela_Usuarios_Grex_1_UserId",
                        column: x => x.UserId,
                        principalTable: "Tabela_Usuarios_Grex_1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tabela_Comentario_Grex_1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UseId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PostId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PostagemId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Texto_Do_Comentario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_Do_Comentario = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Like_Comentario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabela_Comentario_Grex_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tabela_Comentario_Grex_1_Tabela_Postagem_Grex_1_PostagemId",
                        column: x => x.PostagemId,
                        principalTable: "Tabela_Postagem_Grex_1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tabela_Comentario_Grex_1_Tabela_Usuarios_Grex_1_UserId",
                        column: x => x.UserId,
                        principalTable: "Tabela_Usuarios_Grex_1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tabela_Comentario_Grex_1_PostagemId",
                table: "Tabela_Comentario_Grex_1",
                column: "PostagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tabela_Comentario_Grex_1_UserId",
                table: "Tabela_Comentario_Grex_1",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tabela_Postagem_Grex_1_UserId",
                table: "Tabela_Postagem_Grex_1",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tabela_Comentario_Grex_1");

            migrationBuilder.DropTable(
                name: "Tabela_Postagem_Grex_1");

            migrationBuilder.DropTable(
                name: "Tabela_Usuarios_Grex_1");
        }
    }
}
