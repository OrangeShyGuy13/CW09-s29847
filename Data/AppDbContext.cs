using cw09.models;
using Microsoft.EntityFrameworkCore;

namespace cw09.Data;

public class AppDbContext: DbContext
{
    public DbSet<Patient> Patient { get; set; }
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<Medicament> Medicament { get; set; }
    public DbSet<Prescription> Prescription { get; set; }
    public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var doctors = new List<Doctor>
        {
            new()
            {
                IdDoctor = 1,
                FirstName = "Doctor",
                LastName = "Doctorski",
                Email = "doctor@doctor.com",
            }
        };
        var patients = new List<Patient>
        {
            new()
            {
                IdPatient = 1,
                FirstName = "Patient",
                LastName = "Patientski",
                Birthdate = new DateTime(2024, 12, 15, 14, 30, 0)
            }
        };
        var Medicaments = new List<Medicament>
        {
            new()
            {
                IdMedicament = 1,
                Name = "Medicament",
                Description = "Medicament Description",
                Type = "Medicine or something"
            }
        };
        var prescriptions = new List<Prescription>
        {
            new()
            {
                IdPrescription = 1,
                Date = new DateTime(2024, 12, 15, 14, 30, 0),
                DueDate = new DateTime(2025, 12, 15, 14, 30, 0),
                IdPatient = 1,
                IdDoctor = 1
            }
        };
        var prescriptionMedicament = new List<Prescription_Medicament>
        {
            new()
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 2,
                Details = "details",
            }
        };
        modelBuilder.Entity<Doctor>().HasData(doctors);
        modelBuilder.Entity<Patient>().HasData(patients);
        modelBuilder.Entity<Medicament>().HasData(Medicaments);
        modelBuilder.Entity<Prescription>().HasData(prescriptions);
        modelBuilder.Entity<Prescription_Medicament>().HasData(prescriptionMedicament);
        
    }
}