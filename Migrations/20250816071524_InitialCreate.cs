using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemcutikaryawan.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cutis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NamaKaryawan = table.Column<string>(type: "TEXT", nullable: false),
                    TanggalMulai = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TanggalSelesai = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Alasan = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cutis", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cutis");
        }
    }
}
