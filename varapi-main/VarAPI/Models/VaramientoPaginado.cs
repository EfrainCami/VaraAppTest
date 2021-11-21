using System;
using System.Collections.Generic;
using System.Text;

namespace VarAPI.Models
{
    public class VaramientoPaginado
    {
        public Paginacion paginacion { get; set; }
        public List<Varamiento> resultados { get; set; }
    }
}
