﻿using ControleDeContatos.Enums;
using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Usuario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login do Usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o email do usuario")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "Digite o senha do usuario")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
