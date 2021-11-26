using System;
using System.Collections.Generic;

#nullable disable

namespace ClassNoticias.Models
{
    public partial class Noticiass
    {
        public int IdNoticias { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public string Link { get; set; }
        public byte[] Imagen { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdCategorias { get; set; }
        public int? IdPais { get; set; }

        public virtual Categoria IdCategoriasNavigation { get; set; }
        public virtual Paise IdPaisNavigation { get; set; }
    }
}
