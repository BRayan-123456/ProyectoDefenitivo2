using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDefenitivo2.Models
{
    public class Accesorios
    {
        [Display(Name = "Accesorio")]
        public int AccesoriosID { get; set; }
        [Display(Name = "TipoAccesorio")]
        public int TipoAccesorioID { get; set; }
        public TipoAccesorio TipoAccesorio { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Talla { get; set; }
        public int Valor { get; set; }
        public string Color { get; set; }
    }
}
