using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroVisitatori.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Azienda = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Referente = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    MotivoVisita = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    OraIngresso = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OraUscita = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visite", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visite");
        }
    }
}
