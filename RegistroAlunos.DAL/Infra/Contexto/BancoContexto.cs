using Microsoft.EntityFrameworkCore;

namespace RegistroAlunos.Infra.DAL.Contexto
{
    public class BancoContexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=RegistroAlunos;Integrated Security=True;MultipleActiveResultSets=True");
        }

        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
