using Microsoft.EntityFrameworkCore.Migrations;

namespace cw09.Migrations;

public partial class Init: Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Medicament",
            columns: table => new
            {
                IdMedicament = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Medicament", x => x.IdMedicament);
            });
        migrationBuilder.CreateTable(
            name: "Patient",
            columns: table => new
            {
                IdPatient = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Patient", x => x.IdPatient);
            }
        );
        migrationBuilder.CreateTable(
            name: "Doctor",
            columns: table => new
            {
                IdDoctor = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Doctor", x => x.IdDoctor);
            }
        );
        migrationBuilder.CreateTable(
            name: "Prescription",
            columns: table => new
            {
                IdPrescription = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                IdPatient = table.Column<int>(type: "int", nullable: false),
                IdDoctor = table.Column<int>(type: "int", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Prescription", x => x.IdPrescription);
                table.ForeignKey(
                    name: "FK_Prescription_Doctor_IdDoctor",
                    column: x => x.IdDoctor,
                    principalTable: "Doctor",
                    principalColumn: "IdDoctor",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Prescription_Patient_IdPatient",
                    column: x => x.IdPatient,
                    principalTable: "Patient",
                    principalColumn: "IdPatient",
                    onDelete: ReferentialAction.Cascade);
            });
        migrationBuilder.CreateTable(
            name: "Prescription_Medicament",
            columns: table => new
            {
                IdMedicament = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                IdPrescription = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Dose = table.Column<double>(type: "int", nullable: true),
                Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Prescription_Medicament", x => new { x.IdMedicament, x.IdPrescription });
                table.ForeignKey(
                    name: "FK_Prescription_Medicament_IdMedicament",
                    column: x => x.IdMedicament,
                    principalTable: "Medicament",
                    principalColumn: "IdMedicament",
                    onDelete: ReferentialAction.Cascade
                );
                table.ForeignKey(
                    name: "FK_Prescription_Medicament_IdPrescription",
                    column: x => x.IdPrescription,
                    principalTable: "Medicament",
                    principalColumn: "IdMedicament",
                    onDelete: ReferentialAction.Cascade
                );
            }
        );
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Prescription_Medicament");
        migrationBuilder.DropTable(
            name: "Prescription");
        migrationBuilder.DropTable(
            name: "Medicament");
        migrationBuilder.DropTable(
            name: "Doctor");
        migrationBuilder.DropTable(
            name: "Patient");
    }
}