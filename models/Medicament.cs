using System.ComponentModel.DataAnnotations;

namespace cw09.models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    [MaxLength(100)]
    public string Description { get; set; } = null!;
    [MaxLength(100)]
    public string Type { get; set; } = null!;
    
    public virtual ICollection<Prescription_Medicament> prescriptionMedicaments { get; set; } = null!;
}