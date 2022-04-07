using System;
using System.Windows.Forms;
using RegistroAlunos.Infra.Repositorios;

namespace RegistroAlunos
{
    public partial class FrmAluno : Form
    {
        private readonly FrmRegistroAlunos _parent;
        public string  matricula, nome, @classe, turno;
        public long id;
        private readonly AlunoRepositorio repAluno = new AlunoRepositorio();
        public FrmAluno(FrmRegistroAlunos parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            lblText.Text = "Atualizar Aluno";
            btnSave.Text = "Atualizar";
            txtReg.Text = matricula;
            txtName.Text = nome;
            txtClass.Text = @classe;
            txtShift.Text = turno;
        }

        public void SaveInfo()
        {
            lblText.Text = "Cadastrar Aluno";
            btnSave.Text = "Salvar";
        }

        public void Clear()
        {
            txtReg.Text = txtName.Text = txtClass.Text = txtShift.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtReg.Text.Trim().Length < 1)
            {
                MessageBox.Show("A Matrícula do aluno está vazia ou tem menos de 1 caractere.");
                return;
            }
            if (txtName.Text.Trim().Length < 3)
            {
                MessageBox.Show("O Nome do aluno está vazio ou tem menos de 3 caracteres.");
                return;
            }
            if (txtClass.Text.Trim().Length < 2)
            {
                MessageBox.Show("A Classe do aluno está vazia ou incompleta.");
                return;
            }
            if (txtShift.Text.Trim().Length < 5)
            {
                MessageBox.Show("O Turno do aluno está vazio ou incompleto.");
                return;
            }
            if (btnSave.Text == "Salvar")
            {
                Aluno aln = new Aluno();
                aln.Matricula = txtReg.Text.Trim();
                aln.Nome = txtName.Text.Trim();
                aln.Classe = txtClass.Text.Trim();
                aln.Turno = txtShift.Text.Trim();
                repAluno.Adicionar(aln);
                repAluno.SalvarTodos();

                Clear();
            }
            if (btnSave.Text == "Atualizar")
            {
                Aluno aln = new Aluno();

                var aluno_original = repAluno.Find(id);
                

                if (aluno_original.Matricula != txtReg.Text.Trim()
                    || aluno_original.Nome != txtName.Text.Trim()
                    || aluno_original.Classe != txtClass.Text.Trim()
                    || aluno_original.Turno != txtShift.Text.Trim())
                {
                    aluno_original.Matricula = txtReg.Text.Trim();
                    aluno_original.Nome = txtName.Text.Trim();
                    aluno_original.Classe = txtClass.Text.Trim();
                    aluno_original.Turno = txtShift.Text.Trim();
                    repAluno.Atualizar(aluno_original);
                    
                    repAluno.SalvarTodos();
                }
            }
            _parent.Display();
        }
    }
}
