using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChallengeApp.Tests
{   
    public class TypeTest
    {
        public delegate string DelReadEmployeeID(string name);

        [Fact]
        public void CheckWorkingDelegate()
        {
            DelReadEmployeeID del;
            del = GetEmployeeID;
            var result = del("Jonasz");
            Assert.Equal("Jonasz", result);

        }

        public string GetEmployeeID(string name)
        {
            var employee = new Employee(name);
            return employee.Name;
        }

        [Fact]
        public void GetEmployeeReturnsDifferentRefs()
        {
            //arrange
            var employee1 = GetEmployee("Adam");
            var employee2 = GetEmployee("Lolen");
            //act

            //assert
            Assert.Equal("Adam", employee1.Name);
            Assert.Equal("Lolen", employee2.Name);
            Assert.NotSame(employee1, employee2);

        }

        private Employee GetEmployee(string name)
        {
            return new Employee(name);
        }
    }
}
