using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DoctorView
{
    public class Configuration
    {
        public string ConnectionString { get; set; }

        public static Configuration Load(string filename="Appsettings.json")
        {
            var text = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<Configuration>(text);
        }
    
    }
 
}
