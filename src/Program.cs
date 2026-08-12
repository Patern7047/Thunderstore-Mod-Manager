// Thunderstore Mod Manager - Application entry point
using System;
using System.Windows.Forms;

namespace ThunderstoreModManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
