using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.Test
{
    public class AssertingCollectionsTests
    {
        [Fact]
        public void Employee_Skills_ShouldNotHaveEmptySkills()
        {
            //Arrange & Act
            var employee = EmployeeFactory.Create("Giuliano", 10000);

            //Assert
            Assert.All(employee.Skills, skills => Assert.False(string.IsNullOrEmpty(skills)));
        }

        [Fact]
        public void Employee_Skills_JrShouldHaveBasicSkills()
        {
            //Arrange & Act
            var employee = EmployeeFactory.Create("Giuliano", 1000);

            //Assert
            Assert.Contains("Object Oriented Programming", employee.Skills);
        }

        [Fact]
        public void Employee_Skills_JrShouldNotHaveAdvancedSkills()
        {
            //Arrange & Act
            var employee = EmployeeFactory.Create("Giuliano", 1000);

            //Assert
            Assert.DoesNotContain("Microservices", employee.Skills);
        }

        [Fact]
        public void Employee_Skills_SrShouldHaveAllSkills()
        {
            //Arrange & Act
            var employee = EmployeeFactory.Create("Giuliano", 15000);

            var basicSkills = new[]
            {
                "Programming Logic",
                "Object Oriented Programming",
                "Tests",
                "Microservices"
            };
            
            //Assert
            Assert.Equal(basicSkills, employee.Skills);
        }
    }
}
