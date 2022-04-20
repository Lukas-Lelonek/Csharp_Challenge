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
            var emp = new Employee(name);
            return emp.Name;
        }

        [Fact]
        public void GetEmployeeReturnsDifferentRefs()
        {
            //arrange
            var emp1 = GetEmployee("Adam");
            var emp2 = GetEmployee("Lolen");
            //act

            //assert
            Assert.Equal("Adam", emp1.Name);
            Assert.Equal("Lolen", emp2.Name);
            Assert.NotSame(emp1, emp2);

        }

        private Employee GetEmployee(string name)
        {
            return new Employee(name);
        }
    }
}
