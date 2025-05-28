namespace cw09.models.DTO;

public class CreatePrescriptionDto
{
    public PatientDto patient { get; set; } = null!;
    public List<CreateMedicamentDto> medicaments { get; set; } = null!;
    public DateTime date {get; set;}
    public DateTime duedate { get; set; }
    public ShortDoctorDto shortDoctor { get; set; } = null!;
}