using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace ChallengeApp
{
    public class Employee : EmployeeSystemID
    {
        const string FILENAME = "Report_name.txt";

        public delegate void SackWarningDelegate(Employee employee, double grade);
        public event SackWarningDelegate LowGrade;
        private readonly int myId;

        public Employee(string name)
        {
            this.Name = name;
            id += 1;
            this.myId = id;
            this.LowGrade += Employee.WarnSack;
            this.PrepareReport();
        }

        public override List<double> grades
        {
            get
            {
                List<double> gradesInFile = new List<double>();
                using (var inputFile = File.OpenText(FILENAME.Replace("name", this.Name)))
                {
                    var line = inputFile.ReadLine();
                    while (line != null)
                    {
                        var chunk = line.Split(",");
                        gradesInFile.Add(double.Parse(chunk[chunk.Length - 1]));
                        line = inputFile.ReadLine();
                    }
                }
                return gradesInFile;
            }
        }

        public override void IntroduceYourself()
        {
            Console.WriteLine($"My name is {this.Name}.\nMy id is {this.myId}.");
        }

        public static void ChangeName(ref Employee employee, string name)
        {
            bool nameIsValid = true;
            foreach(char chr in name)
            {
                if (char.IsDigit(chr))
                {
                    nameIsValid = false;
                    break;
                }
            }
            if (nameIsValid)
            { employee.Name = name; }
        }

        public override void AddGrade(string grade)
        {
            if (double.TryParse(grade, out double result) && (result >= 0 && result <= 100))
            {
                
                using (var outputFile = File.AppendText(FILENAME.Replace("name", this.Name)))
                {
                    outputFile.WriteLine($"{DateTime.Now},{result}");
                }
                if(LowGrade != null && result < 30)
                {
                    LowGrade(this, result);
                }
            }
        }

        public static Employee GetEmployee(string name, List<Employee> employees)
        {
            
            foreach(var employee in employees)
            {
                if(name == employee.Name)
                { return employee; }
            }
            return null;
        }

        public static void WarnSack(Employee employee, double grade)
        {
            Console.WriteLine($"{employee.Name} has only {grade}! He should be fired!");
        }
        private void PrepareReport()
        {
            string reportFileName = FILENAME.Replace("name", this.Name);
            using (File.Create(reportFileName))
            {
                Debug.WriteLine($"{reportFileName} created");
            }    
        }

    }   
 
}
