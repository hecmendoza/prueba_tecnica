using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyWeb.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Por favor ingrese su nombre.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Por favor ingrese fecha de nacimiento.")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el sexo.")]
        [MinLength(1, ErrorMessage = "Por favor ingrese el sexo.")]
        [MaxLength(1, ErrorMessage = "Por favor ingrese el sexo.")]
        public string Sex { get; set; }
    }

    public enum Gender
    {
        F,
        M
    }
}