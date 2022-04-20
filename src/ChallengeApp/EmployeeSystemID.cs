using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public virtual void IntroduceYourself()
        {
            throw new NotImplementedException();
        }
    }
}
