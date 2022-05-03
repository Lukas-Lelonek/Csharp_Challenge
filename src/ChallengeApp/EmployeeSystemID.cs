using System;
using System.Collections.Generic;
using System.IO;

namespace ChallengeApp
{
    public abstract class EmployeeSystemID : IEmployeeProfile
    {
        public string Name
        {
            get; set;
        }
        public static int id;
        public virtual List<double> grades
        {
            get;
        }

        public virtual void AddGrade(string grade)
        {
            Console.WriteLine($"Grade added: {grade}");
        }

        public virtual void IntroduceYourself()
        {
            Console.WriteLine("This is abstract class");
        }
    }
}
