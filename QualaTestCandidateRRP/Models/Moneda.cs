using System;
using System.Collections.Generic;

namespace QualaTestCandidateRRP.Models
{
    public partial class Moneda
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public string? Simbolo { get; set; }
    }
}
