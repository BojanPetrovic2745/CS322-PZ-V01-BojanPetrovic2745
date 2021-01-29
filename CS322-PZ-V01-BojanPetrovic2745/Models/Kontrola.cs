using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CS322_PZ_V01_BojanPetrovic2745.Models
{
    [Table("Kontrola")]
    public partial class Kontrola
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kontrola()
        {
            Patient_Kontrola = new HashSet<Patient_Kontrola>();
        }

        [Key]
        public int IDkon { get; set; }

        [Column("kontrola")]
        public DateTime kontrola1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient_Kontrola> Patient_Kontrola { get; set; }
    }
}