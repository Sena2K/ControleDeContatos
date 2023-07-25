using System.ComponentModel.DataAnnotations;
using Xunit;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {   
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "O celular não é válido")]
        public string Celular { get; set; }

    }
}
