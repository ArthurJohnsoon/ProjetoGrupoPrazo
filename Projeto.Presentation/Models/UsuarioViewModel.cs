using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            PermissaoList = new List<System.Web.Mvc.SelectListItem>()
            {
                new System.Web.Mvc.SelectListItem(){ Value = "", Text="SELECIONE", Selected = true},
                new System.Web.Mvc.SelectListItem(){ Value = "ADMINISTRADOR", Text="ADMINISTRADOR" },
                new System.Web.Mvc.SelectListItem(){ Value = "USUÁRIO BASICO", Text="BASICO"},
            };
        }

        public int UsuarioId { get; set; }
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Informe o e-mail.")]
        public string Email { get; set; }


        public List<System.Web.Mvc.SelectListItem> PermissaoList { get; set; }

        [Required(ErrorMessage = "Informe a permissão do usuário.")]
        public string Permissao { get; set; }

        [Required(ErrorMessage = "Informe o login.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Confirme a senha.")]
        public string SenhaConfirm { get; set; }


    }
}