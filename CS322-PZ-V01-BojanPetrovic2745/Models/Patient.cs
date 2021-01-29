using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CS322_PZ_V01_BojanPetrovic2745.Models
{
    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            Patient_Kontrola = new HashSet<Patient_Kontrola>();
        }

        [Key]
        public int IDpa { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("[a-zA-Z]+")]
        public string ime { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("[a-zA-Z]+")]
        public string prezime { get; set; }

        [Required]
        [StringLength(13)]
        [MinLength(13)]
        [RegularExpression("^[0-9]*$")]
        public string jmbg { get; set; }

        [Required]
        [StringLength(255)]
        public string simptomi { get; set; }

        [Required]
        [StringLength(255)]
        public string terapija { get; set; }

        public bool izlecen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient_Kontrola> Patient_Kontrola { get; set; }
    }
}