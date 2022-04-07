using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAlunos
{
    public class Usuario
    {
        [Key]
        public long UsuarioID { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

    }
}
