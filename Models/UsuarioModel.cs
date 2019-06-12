using System;
using Microsoft.Extensions.Primitives;

namespace Pontodigitaloficial.Models
{
    public class UsuarioModel
    {
        
        public UsuarioModel(int id, string nome, DateTime dataNascimento, string email, string endereco, int telefone, string senha) 
        {
            this.Id = id;
                this.Nome = nome;
                this.DataNascimento = dataNascimento;
                this.Email = email;
                this.Endereco = endereco;
                this.Telefone = telefone;
                this.Senha = senha;
               
        }
        public int Id {get; set;}

        public string Nome {get; set;}

        public DateTime DataNascimento {get; set;}

        public string Email {get;set;}

        public string Endereco {get; set;}

        public GeneroModel Genero {get; set;}

        public int Telefone {get; set;}

        public string Senha {get; set;}

        
    }
}