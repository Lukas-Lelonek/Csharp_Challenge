using System;
using System.Linq;
using System.Collections.Generic;

namespace ChallengeApp
{
    
    
        public static class Statistics 
        { 
        public static Dictionary<string,double> ShowStatistics(Employee employee)

        {
            try
            {
                var Data = new Dictionary<string, double>();
                Data.Add("Max", employee.grades.Max());
                Data.Add("Min", employee.grades.Min());
                Data.Add("Avg", employee.grades.Average());

                Console.WriteLine($"{employee.Name} Number of grades: {employee.grades.Count()}");
                Console.WriteLine($"{employee.Name} Highest grade: {employee.grades.Max()}");
                Console.WriteLine($"{employee.Name} Lowest grade: {employee.grades.Min()}");
                Console.WriteLine($"{employee.Name} Average grade: {employee.grades.Average():N2}");

                return Data;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{employee.Name} has no grades to calculate.");
                return null;
            }
        }
        }
            

}
