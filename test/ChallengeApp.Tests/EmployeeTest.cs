using System;
using Xunit;
using System.Collections.Generic;
using ChallengeApp;

namespace ChallengeApp.Tests
{
    public class EmployeeTest
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var emp = new Employee("Lolen");
            emp.AddGrade("10");
            emp.AddGrade("20");
            emp.AddGrade("30");

            //Act
            Dictionary<string, double> Data = Statistics.ShowStatistics(emp);
            double expectedMax = 30;
            double expectedMin = 10;
            double expectedAvg = 20;

            double actualMax = Data.GetValueOrDefault("Max");
            double actualMin = Data.GetValueOrDefault("Min");
            double actualAvg = Data.GetValueOrDefault("Avg");

            //assert
            Assert.Equal(expectedMax, actualMax,1);
            Assert.Equal(expectedMin, actualMin, 1);
            Assert.Equal(expectedAvg, actualAvg, 1);
        }
    }
}
