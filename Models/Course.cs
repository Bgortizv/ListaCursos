using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaCursos.Models
{
    public class Course
    {

        public int id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [MaxLength(500, ErrorMessage = "Máximo 500 caracteres.")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Autor(a)")]
        public string Author { get; set; }
        [Url(ErrorMessage = "La dirección no es válida.")]
        [Display(Name = "Dirección electrónica del curso.")]
        public string Url { get; set; }
    }
}
