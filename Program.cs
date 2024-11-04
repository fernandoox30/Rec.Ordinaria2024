using Refuerzo2024.View.Dashboard;
using System;
using System.Windows.Forms;

namespace Refuerzo2024
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ViewDashboard());
        }
    }
}
