using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class VueloMetadatos
    {
        [Display(Name = "Número de vuelo")]
        [Required(ErrorMessage ="Ingrese un número de vuelo")]
        public string Numero { get; set; }

        [Display(Name = "Horario de llegada")]
        [Required(ErrorMessage = "Ingrese un horario de llegada")]
        [DisplayFormat(DataFormatString="{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public System.TimeSpan HorarioLlegada { get; set; }

        [Display(Name =  "Línea / Compañía aérea")]
        [Required(ErrorMessage = "Ingrese el nombre de la linea aerea")]
        public string LineaAerea { get; set; }

        [Display(Name = "Está demorado")]
        public int Demorado { get; set; }
    }
}
