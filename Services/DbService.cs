using cw09.Data;
using cw09.models;
using cw09.models.DTO;

using Microsoft.EntityFrameworkCore;
namespace cw09.Services;

public interface IDbService
{
    public Task<GetPatientDto> GetPatient(int id);
    public Task CreatePrescription(CreatePrescriptionDto prescription);
}

public class DbService(AppDbContext data) : IDbService
{
    public async Task<GetPatientDto> GetPatient(int patientid)
    {
        var result = await data.Patient.AsQueryable().Where(pt => pt.IdPatient == patientid)
            .Select(pt => new GetPatientDto
            {
                IdPatient = pt.IdPatient,
                FirstName = pt.FirstName,
                LastName = pt.LastName,
                Birthdate = pt.Birthdate,
                Prescriptions = pt.Prescriptions.OrderByDescending(pr => pr.DueDate).Select(pr => new PrescriptionsDto
                {
                    IdPrescription = pr.IdPrescription,
                    Date = pr.Date,
                    DueDate = pr.DueDate,
                    Medicaments = pr.prescriptionMedicaments.Select(pm => new MedicamentDto
                    {
                        IdMedicament = pm.Medicament.IdMedicament,
                        Name = pm.Medicament.Name,
                        Description = pm.Medicament.Description,
                        Type = pm.Medicament.Type
                    }).ToList(),
                    Doctor = new ShortDoctorDto
                    {
                        IdDoctor = pr.Doctor.IdDoctor,
                        FirstName = pr.Doctor.FirstName,
                    }
                }).ToList()
            }).FirstOrDefaultAsync();
        if (result != null)
        {
            return result;
        }
        throw new Exception($"Patient with ID {patientid} not found");
    }
    public async Task CreatePrescription(CreatePrescriptionDto model)
        {
            if (model.medicaments.Count > 10)
                throw new Exception("Too many medicaments");
            if (model.duedate < model.date)
                throw new Exception("DueDate cannot be before date");
            var patient = await data.Patient.FindAsync(model.patient.IdPatient);
            if (patient == null)
            {
                patient = new Patient()
                {
                    FirstName = model.patient.FirstName,
                    LastName = model.patient.LastName,
                    Birthdate = model.patient.DateOfBirth
                };
                data.Patient.Add(patient);
                await data.SaveChangesAsync();
            }
            var doctor = await data.Doctor.FindAsync(model.shortDoctor.IdDoctor);
            if (doctor == null)
                throw new Exception("Doctor not found.");
            var medicamentIds = model.medicaments.Select(m => m.IdMedicament).ToList();
            var medicaments = await data.Medicament
                .Where(m => medicamentIds.Contains(m.IdMedicament))
                .ToListAsync();
            if (medicaments.Count != model.medicaments.Count)
                throw new Exception("One or more medicaments do not exist");
            var prescription = new Prescription
            {
                Date = model.date,
                DueDate = model.duedate,
                IdPatient = patient.IdPatient,
                IdDoctor = doctor.IdDoctor,
            };
            data.Prescription.Add(prescription);
            await data.SaveChangesAsync();
            foreach (var medicament in model.medicaments)
            {
                var prescriptionMedicament = new Prescription_Medicament()
                {
                    IdMedicament = medicament.IdMedicament,
                    IdPrescription = prescription.IdPrescription,
                    Dose = medicament.Dose,
                    Details = medicament.Details,
                };
                data.Prescription_Medicament.Add(prescriptionMedicament);
            }
            await data.SaveChangesAsync();
        }
}