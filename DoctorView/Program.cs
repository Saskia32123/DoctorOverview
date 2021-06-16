using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DoctorView
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var appsettings = Configuration.Load();
            var optionsBuilder = new DbContextOptionsBuilder<DoctorView.DoctorContext>();
            optionsBuilder.UseSqlServer(appsettings.ConnectionString);
            var textfile = ReadTextFile("IMPORT.TXT");
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            var doctors = Doctor.DeserializeDoctors(textfile);
            var datacontext = new DoctorContext(optionsBuilder.Options);
            datacontext.AddToDatabase(doctors);
            
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static IEnumerable<string> ReadTextFile(string path)
        {
            return System.IO.File.ReadLines(path).Select(t => t.Trim());
        }

    }
}