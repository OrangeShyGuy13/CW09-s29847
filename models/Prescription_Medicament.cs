using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace cw09.models;

[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdMedicament),nameof(IdPrescription))]
public class Prescription_Medicament
{
    [Column("IdMedicament")]
    public int IdMedicament { get; set; }
    [Column("IdPrescription")]
    public int IdPrescription { get; set; }
    
    public int Dose { get; set; }
    [MaxLength(100)]
    public string Details { get; set; } = null!;
    
    [ForeignKey(nameof(IdMedicament))]
    public virtual Medicament Medicament { get; set; } = null!;
    
    [ForeignKey(nameof(IdPrescription))]
    public virtual Prescription prescription { get; set; } = null!;
    
}