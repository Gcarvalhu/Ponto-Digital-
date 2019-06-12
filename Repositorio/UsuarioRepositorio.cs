using System;
using System.Collections.Generic;
using System.IO;
using Pontodigitaloficial.Models;

namespace Pontodigitaloficial.Repositorio {
    public class UsuarioRepositorio {
        private const string PATH = "Database/usuarios.csv";
        public UsuarioModel Cadastrar (UsuarioModel usuario) {
            if (File.Exists (PATH)) {
                usuario.Id = File.ReadAllLines (PATH).Length + 1;
            } else {
                usuario.Id = 1;
            }
            StreamWriter sw = new StreamWriter (PATH, true);
            sw.WriteLine ($"{usuario.Id};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.DataNascimento};{usuario.Telefone};{usuario.Endereco}");
            sw.Close ();

            return usuario;
        }
        public List<UsuarioModel> Listar () {
            List<UsuarioModel> listaDeUsuarios = new List<UsuarioModel> ();
            string[] linhas = File.ReadAllLines (PATH);
            UsuarioModel usuario;

            foreach (var item in linhas) {
                if (string.IsNullOrEmpty (item)) {
                    //sair do foreach
                    continue;
                }
                string[] linha = item.Split (";");

                usuario = new UsuarioModel (
                    id: int.Parse (linha[0]),
                    nome: linha[1],
                    email: linha[2],
                    senha: linha[3],
                    dataNascimento: DateTime.Parse (linha[4]),
                    telefone: int.Parse (linha[5]),
                    endereco: linha[6]
                );
                listaDeUsuarios.Add (usuario);
            }
            return listaDeUsuarios;
        }
    }
}