using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace ControleDeContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o nome do Usuario")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha do Usuario")]
        public string Senha { get; set; }
    }
}
