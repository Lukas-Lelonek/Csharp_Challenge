using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{
    public static class EmployeesFiles
    {
        public static void GetEmployeesFromFiles(ref List<Employee> employees)
        {
            
            string[] Files = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach(var file in Files)
            {
                if(file.Contains("Report"))
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    string name = fileName.Replace("Report_", "");
                    var employee = new Employee(name);
                    employees.Add(employee);
                }
            }
        }
    }
}
