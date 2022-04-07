using System;
using System.Windows.Forms;
using RegistroAlunos.Modelo;

namespace RegistroAlunos.Apresentação
{
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {

            Controle controle = new Controle();
            controle.Acessar(loginUsuario.Text, senhaUsuario.Text);


            if (controle.mensagem.Equals(""))
            {
                if (controle.permitido)
                {
                    FrmRegistroAlunos FrmRA = new FrmRegistroAlunos();
                    FrmRA.Show();
                    this.Hide();
                    MessageBox.Show("Bem Vindo ao Registro de Alunos!", "Entrando...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    senhaUsuario.Clear();
                    MessageBox.Show("Login ou Senha Inválidos, verifique login e senha!", "Falha no Acesso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                MessageBox.Show(controle.mensagem);
            }

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var btnExit = MessageBox.Show(this, "Você tem certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo);

            if (btnExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            FrmCadastro FrmCad = new FrmCadastro(this);
            FrmCad.ShowDialog();
        }
    }
}
