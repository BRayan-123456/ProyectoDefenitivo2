using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDefenitivo2.Models
{
    public class Persona
    {
        [Display(Name = "Persona")]
        public int PersonaID { get; set; }
        [Display(Name = "TipoPersona")]
        public int TipoPersonaID { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Documento { get; set; }
        public string Sexo { get; set; }
        public string CorreoElectronico { get; set; }
        public string Discapacidad { get; set; }
        public string Antecedentes { get; set; }
        public string Login { get; set; }
        public string Clave { get; set; }
    }
}
