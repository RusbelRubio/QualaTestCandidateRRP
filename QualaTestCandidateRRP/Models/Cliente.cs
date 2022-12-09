using System;
using System.Collections.Generic;

namespace QualaTestCandidateRRP.Models
{
    public partial class Cliente
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public int IdMoneda { get; set; }
        public DateTime FechaTransaccion { get; set; }
    }
}
