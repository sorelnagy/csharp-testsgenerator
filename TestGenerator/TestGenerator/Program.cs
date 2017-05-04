using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestGenerator.data.service;

namespace TestGenerator
{

    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        internal static extern Boolean AllocConsole();
    }



    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            NativeMethods.AllocConsole();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AdminService admin = new AdminService();

            admin.addUser();
            admin.readUser();
            admin.updateUser();
            admin.deleteUser();

            Application.Run(new Form1());
        }
    }
}
