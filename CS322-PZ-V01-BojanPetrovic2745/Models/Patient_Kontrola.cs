using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS322_PZ_V01_BojanPetrovic2745.Models
{
    public partial class Patient_Kontrola
    {
        public int ID { get; set; }

        public int PatientID { get; set; }

        public int KontroalD { get; set; }

        public virtual Kontrola Kontrola { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
