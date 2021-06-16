using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DoctorView
{
    public class Doctor
    {
        [Key]
        [Required]
        int ArztID { get; set; }
        string Name { get; set; }
        string Telefon { get; set; }
        int Alter { get; set; }
        DateTime Eintritt { get; set; }
        DateTime? Austritt { get; set; }
        
        internal static IEnumerable<Doctor> DeserializeDoctors(IEnumerable<string> doctors)
        {
            List<Doctor> doctorList = new List<Doctor>();
            foreach (var doc in doctors)
            {
                int number;
                var strings = doc.Split(';');

                var doctor = new Doctor { };
                if (int.TryParse(strings[0], out number)) {
                    doctor.ArztID = number;
                }
                doctor.Name = strings[1];
                doctor.Telefon = strings[2];
                if (int.TryParse(strings[3], out number))
                {
                    doctor.Alter = number;
                }
                if (int.TryParse(strings[4], out number))
                {
                    doctor.Eintritt = DateTime.Parse(strings[4]);
                }
                if (!String.IsNullOrWhiteSpace(strings[5]))
                {
                    doctor.Austritt = DateTime.Parse(strings[5]);
                }
                else
                {
                    doctor.Austritt = null;
                }

                doctorList.Add(doctor);
            }

            return doctorList;
        }
    }
}