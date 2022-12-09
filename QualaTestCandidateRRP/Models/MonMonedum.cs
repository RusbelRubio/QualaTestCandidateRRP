using System;
using System.Collections.Generic;

namespace QualaTestCandidateRRP.Models
{
    public partial class MonMonedum
    {
        public int CodMoneda { get; set; }
        public string Moneda { get; set; } = null!;
        public string Abrev { get; set; } = null!;
    }
}
