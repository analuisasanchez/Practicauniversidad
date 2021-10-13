using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversidadWeb.Models
{
    public enum SemestreType
    {
        Semestre1 = 0,
        Semestre2 = 1,
        Semestre3 = 2,
        Semestre4 = 3,
        Semestre5 = 4,
        Semestre6 = 5,
        Semestre7 = 6,
        Semestre8 = 7,
        Semestre9 = 8,
        Semestre10 = 9,
        Tesis = 10
    }

    public class Universidad
    {
        [Key]
        public int EstudianteId { get; set; }


        [Required(ErrorMessage = "Porfavor ingrese su nombre")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Su nombre debe contener mas de 3 letras")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }



        [Required(ErrorMessage = "Porfavor ingrese su numero de registro")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Su numero de registro debe contener 10 digitos")]
        [Display(Name = "Numero de Registro")]
        public string Registro { get; set; }





        [Required(ErrorMessage = "El semestre es requerido")]
        [Display(Name = "Selecciona tu semestre")]
        public SemestreType Semestre { get; set; }



    }
}
