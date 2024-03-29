using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ponto_Digital_.Models;
using Ponto_Digital_.Repositorio;

namespace Pontodigitaloficial.Controllers {
    public class CadastroController : Controller {
         public ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
        public IActionResult Index(){
            
            return View();
           
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection form){

            ClienteModel cliente = new ClienteModel();
            cliente.Nome = form["nome"];
            cliente.Endereco = form["endereco"];
            cliente.Telefone = form["telefone"];
            cliente.Senha = form["senha"];
            cliente.Email = form["email"];
            cliente.DataNascimento = DateTime.Parse(form["data-nascimento"]);

            clienteRepositorio.Inserir(cliente);

            ViewData["Action"] = "Cadastro";

            return View("Index",clienteRepositorio);
        }
    }
}