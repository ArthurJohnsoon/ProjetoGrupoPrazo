using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o login de acesso.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe a senha de acesso.")]
        public string Senha { get; set; }
    }
}