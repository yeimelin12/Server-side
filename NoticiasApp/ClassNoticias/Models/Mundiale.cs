using System;
using System.Collections.Generic;

#nullable disable

namespace ClassNoticias.Models
{
    public partial class Mundiale
    {
        public Mundiale()
        {
            Paises = new HashSet<Paise>();
        }

        public int IdMundiales { get; set; }
        public string Continente { get; set; }

        public virtual ICollection<Paise> Paises { get; set; }
    }
}
