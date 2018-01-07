using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locker
{
    static class Program
    {
        public static bool Allow_exit = false;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (!Allow_exit)
            {     
                Application.Run(new Form1());
            }
        }
    }
}
