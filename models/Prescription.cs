using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw09.models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    [Column("IdPatient")]
    public int IdPatient { get; set; }
    [Column("IdDoctor")]
    public int IdDoctor { get; set; }
    [ForeignKey(nameof(IdDoctor))]
    public virtual Doctor Doctor { get; set; } = null!;
    [ForeignKey(nameof(IdPatient))]
    public virtual Patient Patient { get; set; } = null!;
    public virtual ICollection<Prescription_Medicament> prescriptionMedicaments { get; set; } = null!;
}