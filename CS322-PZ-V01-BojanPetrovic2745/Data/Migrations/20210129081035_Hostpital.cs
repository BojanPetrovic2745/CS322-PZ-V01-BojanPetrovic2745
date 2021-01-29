using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS322_PZ_V01_BojanPetrovic2745.Data.Migrations
{
    public partial class Hostpital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontrola",
                columns: table => new
                {
                    IDkon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kontrola = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontrola", x => x.IDkon);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    IDpa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    jmbg = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    simptomi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    terapija = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    izlecen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.IDpa);
                });

            migrationBuilder.CreateTable(
                name: "Patient_Kontrola",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    KontroalD = table.Column<int>(type: "int", nullable: false),
                    KontrolaIDkon = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Kontrola", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patient_Kontrola_Kontrola_KontrolaIDkon",
                        column: x => x.KontrolaIDkon,
                        principalTable: "Kontrola",
                        principalColumn: "IDkon",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Kontrola_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "IDpa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Kontrola_KontrolaIDkon",
                table: "Patient_Kontrola",
                column: "KontrolaIDkon");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Kontrola_PatientID",
                table: "Patient_Kontrola",
                column: "PatientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient_Kontrola");

            migrationBuilder.DropTable(
                name: "Kontrola");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
