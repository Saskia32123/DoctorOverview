using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorView;
using Microsoft.EntityFrameworkCore;

namespace DoctorView
{
    public class DoctorContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DoctorContext(DbContextOptions<DoctorContext> options)
            : base(options)
        {

        }

        public void AddToDatabase(IEnumerable<Doctor> doctors)
        {
            foreach (var doctor in doctors)
            {
                Doctors.Add(doctor);
            }
            SaveChanges();
        }
    }
}
