using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RegistroAlunos.Infra.DAL.Contexto;
using RegistroAlunos.Infra.Repositorios;

namespace RegistroAlunos
{
    public partial class FrmRegistroAlunos : Form
    {

        private readonly AlunoRepositorio repAluno = new AlunoRepositorio();

        FrmAluno frm;


        public FrmRegistroAlunos()
        {
            InitializeComponent();
            frm = new FrmAluno(this);
        }

        public void Display()
        {

            List<Aluno> alunos;
            dataGridView.Rows.Clear();

            using (var ctx = new BancoContexto())
            {
                alunos = ctx.Aluno.ToList();
            }

            foreach (var aluno in alunos)
                dataGridView.Rows.Add(aluno.AlunoID, aluno.Matricula, aluno.Nome, aluno.Classe, aluno.Turno);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frm.Clear();
            frm.SaveInfo();
            frm.ShowDialog();
        }

        private void FrmRegistroAlunos_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            List<Aluno> alunos;
            dataGridView.Rows.Clear();

            using (var ctx = new BancoContexto())
            {
                alunos = ctx.Aluno.ToList();
            }

            foreach (var aluno in alunos)
            {
                if (aluno.Nome.Contains(txtSearch.Text))
                {
                    dataGridView.Rows.Add(aluno.AlunoID, aluno.Matricula, aluno.Nome, aluno.Classe, aluno.Turno);
                }

                if (string.IsNullOrEmpty(aluno.Nome))
                {
                    dataGridView.Rows.Add(aluno.AlunoID, aluno.Matricula, aluno.Nome, aluno.Classe, aluno.Turno);
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                //Botão de Editar
                frm.Clear();
                frm.id = (long)dataGridView.Rows[e.RowIndex].Cells[0].Value;
                frm.matricula = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.nome = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.@classe = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.turno = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();

                frm.UpdateInfo();
                frm.ShowDialog();

                return;
            }
            if (e.ColumnIndex == 6)
            {
                //Botão de Excluir
                if (MessageBox.Show("Você tem certeza que deseja deletar o aluno?", "AVISO!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //var alnR = new AlunoRepositorio();

                    var id = (long)dataGridView.Rows[e.RowIndex].Cells[0].Value;

                    Aluno aluno = repAluno.Find(id);
                    repAluno.Excluir(a => a == aluno);
                    repAluno.SalvarTodos();
                    Display();
                }
                return;
            }
        }

    }
}
