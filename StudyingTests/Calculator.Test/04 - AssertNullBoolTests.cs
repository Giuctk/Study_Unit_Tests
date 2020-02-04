using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.Test
{
    public class AssertNullBoolTests
    {
        [Fact]
        public void Employee_Name_ShouldNotBeNullOrEmpty()
        {
            //Arrange & Act
            var employee = new Employee("", 1000);
            //Assert
            Assert.False(string.IsNullOrEmpty(employee.Name));
        }

        [Fact]
        public void Employee_NickName_ShouldNotHaveNickName()
        {
            //Arrange & Act
            var employee = new Employee("Giulaino", 1000);

            //Assert
            Assert.Null(employee.NickName);

            //Assert Bool
            Assert.True(string.IsNullOrEmpty(employee.NickName));
            Assert.False(employee.NickName?.Length > 0);
        }
    }
}
