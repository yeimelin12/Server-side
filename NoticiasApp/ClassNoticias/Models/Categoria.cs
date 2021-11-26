using System;
using System.Collections.Generic;

#nullable disable

namespace ClassNoticias.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Noticiasses = new HashSet<Noticiass>();
        }

        public int IdCategorias { get; set; }
        public string Categoria1 { get; set; }

        public virtual ICollection<Noticiass> Noticiasses { get; set; }
    }
}
