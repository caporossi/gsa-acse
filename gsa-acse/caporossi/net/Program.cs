using System;
using System.Windows.Forms;
using System.Reflection;

namespace gsa_acse.caporossi.net
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Log.Instance.Info("Start gsa-acse versione " + version.ToString());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}
