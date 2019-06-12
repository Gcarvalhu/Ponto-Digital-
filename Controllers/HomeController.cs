using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pontodigitaloficial.Models;
using Pontodigitaloficial.Repositorio;

namespace Pontodigitaloficial.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(){

            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(IFormCollection form){
            UsuarioModel usuario = new UsuarioModel(
                id: int.Parse(form["id"]),
                nome: form["nome"],
                email: form["email"],
                senha: form["senha"],
                endereco: form["endereco"],
                dataNascimento: DateTime.Parse(form["dataNascimento"]),
                telefone: int.Parse(form["telefone"])
            );

            UsuarioRepositorio usuarioRepositorio =  new UsuarioRepositorio();
            usuarioRepositorio.Cadastrar(usuario);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Listar(){
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            ViewData["usuarios"] = usuarioRepositorio.Listar();

            return View();
			}
    }
}