using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RegistroAlunos.Apresentação;
using RegistroAlunos.Infra.Repositorios;

namespace RegistroAlunos.Aplicacao
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}
