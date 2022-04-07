using System.ComponentModel.DataAnnotations;

namespace RegistroAlunos
{
    public class Aluno
    {

        /// <summary>
        /// ID do aluno
        /// </summary>
        [Key]
        public long AlunoID { get; set; }
        /// <summary>
        /// Matricula do aluno
        /// </summary>
        public string Matricula { get; set; }
        /// <summary>
        /// Nome do aluno
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Classe do aluno
        /// </summary>
        public string Classe { get; set; }
        /// <summary>
        /// Turno do aluno
        /// </summary>
        public string Turno { get; set; }

    }
}
