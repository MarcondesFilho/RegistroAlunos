using System;
using System.Windows.Forms;
using RegistroAlunos.Apresentação;
using RegistroAlunos.Infra.Repositorios;
using RegistroAlunos.Repositório;

namespace RegistroAlunos
{
    public partial class FrmCadastro : Form
    {
        private readonly FrmLogin _parent;
        public string email, login, senha, confSenha;
        public long id;
        private readonly UsuarioRepositorio repUsuario = new UsuarioRepositorio();
        public FrmCadastro(FrmLogin parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void SaveInfo()
        {
            lblText.Text = "Cadastrar Usuário";
            btnCadastrar.Text = "Cadastrar";
        }

        public void Clear()
        {
            txtEmail.Text = txtLogin.Text = txtSenha.Text = txtConfSenha.Text = string.Empty;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim().Length < 1)
            {
                MessageBox.Show("O Email está vazio ou incompleto.");
                return;
            }
            if (txtLogin.Text.Trim().Length < 3)
            {
                MessageBox.Show("O Login está vazio ou tem menos de 3 caracteres.");
                return;
            }
            if (txtSenha.Text.Trim().Length < 6)
            {
                MessageBox.Show("A Senha está vazia ou incompleta. Minimo de 6 dígitos.");
                return;
            }
            if (txtConfSenha.Text.Trim().Equals(txtSenha))
            {
                MessageBox.Show("A Confirmação de senha não corresponde a senha informada!");
                return;
            }
            if (btnCadastrar.Text == "Cadastrar")
            {
                Usuario user = new Usuario();
                user.Email = txtEmail.Text.Trim();
                user.Login = txtLogin.Text.Trim();
                user.Senha = txtSenha.Text.Trim();

                user.Senha = CriptografiaRepositorio.Criptografar(user.Senha);

                repUsuario.Adicionar(user);
                repUsuario.SalvarTodos();

                MessageBox.Show("Usuário Cadastrado com Sucesso!");
                this.Hide();

                Clear();
            }
        }
    }
}
