using System;
using RegistroAlunos.DAL;

namespace RegistroAlunos.Modelo
{
    public class Controle
    {
        public bool permitido;
        public String mensagem = "";
        public bool Acessar(string login, string senha)
        {
            LoginComandos LDC = new LoginComandos();

            permitido = LDC.VerificarLogin(login, senha);

            if (!LDC.mensagem.Equals(""))
            {
                this.mensagem = LDC.mensagem;
            }

            return permitido;
        }
    }
}
