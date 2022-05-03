using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>();
            string response;

            EmployeesFiles.GetEmployeesFromFiles(ref employees);

            do
            {
                Console.WriteLine("Welcome To Staff Grader 1987\n\nPress for following actions:");
                Console.WriteLine("1 - Add New Employee\n2 - Select Employee\n3 - Show Statistics\nexit");
                response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        Console.WriteLine("Provide Employee Name:");
                        employees.Add(new Employee(Console.ReadLine()));
                        break;
                    case "2":
                        foreach(var employee in employees)
                        {
                            Console.WriteLine(employee.Name);
                        }
                        Console.WriteLine("Please write Employee Name and add grade");
                        var emp = Employee.GetEmployee(Console.ReadLine(), employees);
                        if (emp != null)
                            {
                            
                            Console.WriteLine($"Provide grade for {emp.Name}");
                            emp.AddGrade(Console.ReadLine());
                            }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Sorry, no such employee.\n");
                        }
                        break;
                    case "3":
                        foreach(var employ in employees)
                        {
                            employ.IntroduceYourself();
                            Console.WriteLine("-----");
                            Statistics.ShowStatistics(employ);
                            Console.WriteLine("^^^^^");
                        }
                        break;
                    default:
                        response = "exit";
                        break;
                }
            }

            while (response != "exit");

        }
    }
}
