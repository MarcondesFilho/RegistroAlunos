using System;
using System.Linq;
using RegistroAlunos.Infra.Repositorios;
using RegistroAlunos.Repositório;

namespace RegistroAlunos.DAL
{
    public class LoginComandos
    {
        public string mensagem = "";
        public string senhaCriptografada;
        private readonly UsuarioRepositorio repUsuario = new UsuarioRepositorio();


        public bool VerificarLogin(string login, string senha)
        {
            senhaCriptografada = CriptografiaRepositorio.Criptografar(senha);
            senha = senhaCriptografada;

            bool ehUmUsuarioDoSistema = repUsuario.Get(entU => entU.Login == login && entU.Senha == senha).Select(entU => entU.UsuarioID).FirstOrDefault() > 0;

            return ehUmUsuarioDoSistema;
        }

        //public string CadastrarUsuario(string email, string login, string senha, string ConfSenha)
        //{
        //    if (senha.Equals(ConfSenha))
        //    {
        //        senhaCriptografada = CriptografiaRepositorio.Criptografar(senha);
        //        senha = senhaCriptografada;

        //        Usuario entUsuario = new Usuario();
        //        entUsuario.Email = email;
        //        entUsuario.Login = login;
        //        entUsuario.Senha = senha;

        //        bool ehUmUsuarioDoSistema = repUsuario.Get(entU => entU.Login == login && entU.Senha == senha).Select(entU => entU.UsuarioID).FirstOrDefault() > 0;
        //    }
        //    return mensagem;
        //}
    }
}
