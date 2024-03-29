﻿using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsarioRepositorio _usarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsarioRepositorio usarioRepositorio, ISessao sessao)
        {
            _usarioRepositorio = usarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            if(_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");


            return View();
        }

        public IActionResult Sair()

        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
        }


            [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usarioRepositorio.BuscarLogin(loginModel.Login);
                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha incorretos, tente novamente";
                    }
                    TempData["MensagemErro"] = $"Usuario ou senha incorretos, tente novamente";
                }
                return View("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel fazer seu login, tente novamente. {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
