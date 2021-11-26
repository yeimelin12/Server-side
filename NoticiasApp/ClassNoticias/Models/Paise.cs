using System;
using System.Collections.Generic;

#nullable disable

namespace ClassNoticias.Models
{
    public partial class Paise
    {
        public Paise()
        {
            Noticiasses = new HashSet<Noticiass>();
        }

        public int IdPais { get; set; }
        public string Pais { get; set; }
        public int? IdMundiales { get; set; }

        public virtual Mundiale IdMundialesNavigation { get; set; }
        public virtual ICollection<Noticiass> Noticiasses { get; set; }
    }
}
