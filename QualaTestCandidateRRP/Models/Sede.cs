using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QualaTestCandidateRRP.Models
{
    public partial class Sede
    {
        [Required]
        [Range (1000,99999999)]
        public int Codigo { get; set; }
        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; } = null!;
        [Required]
        [StringLength(250)]
        public string Direccion { get; set; } = null!;
        [Required]
        [StringLength(250)]
        public string Identificacion { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string NombreMoneda { get; set; } = null!;
        public DateTime FechaTransaccion { get; set; }
    }
}
