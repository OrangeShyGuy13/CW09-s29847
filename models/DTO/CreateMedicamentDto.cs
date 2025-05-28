namespace cw09.models.DTO;

public class CreateMedicamentDto
{
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; } = null!;
    public string Details { get; set; } = null!;
}