namespace cw09.models.DTO;

public class PrescriptionsDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<MedicamentDto> Medicaments { get; set; } = null!;
    public ShortDoctorDto Doctor {get; set;} = null!;
}