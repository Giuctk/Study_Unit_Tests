using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.Test
{
    public class AssertingObjectTypesTests
    {
        [Fact]
        public void EmployeeFactory_Create_ShouldReturnEmployeeType()
        {
            //Arrange & Act
            var employee = EmployeeFactory.Create("Giuliano", 10000);

            //Assert
            Assert.IsType<Employee>(employee);
        }

        [Fact]
        public void EmployeeFactory_Create_ShouldReturnTypeInheritPerson()
        {
            //Arrange & Act
            var employee = EmployeeFactory.Create("Giuliano", 10000);

            //Assert
            Assert.IsAssignableFrom<Person>(employee);
        }
    }
}
