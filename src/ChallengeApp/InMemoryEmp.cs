using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp
{

    public class InMemoryEmp  : EmployeeSystemID

    {
        public delegate void SackWarningDelegate(InMemoryEmp employee, double grade);
        public event SackWarningDelegate LowGrade;
        private readonly int myId;

        public InMemoryEmp(string name)
        {
            this.Name = name;
            id += 1;
            this.myId = id;

        }

        public override void IntroduceYourself()
        {
            Console.WriteLine($"My name is {this.Name}.\nMy id is {this.myId}.");
        }

        public static void ChangeName(ref InMemoryEmp employee, string name)
        {
            bool nameIsValid = true;
            foreach (char chr in name)
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
                grades.Add(result);

                if (LowGrade != null && result < 30)
                {
                    LowGrade(this, result);
                }
            }
        }

        public static InMemoryEmp GetEmployee(string name, List<InMemoryEmp> employees)
        {

            foreach (var employee in employees)
            {
                if (name == employee.Name)
                { return employee; }
            }
            return null;
        }

        public static void WarnSack(InMemoryEmp employee, double grade)
        {
            Console.WriteLine($"{employee.Name} has only {grade}! He should be fired!");
        }
    }
}


