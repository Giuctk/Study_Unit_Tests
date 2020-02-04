using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.Test
{
    public class AssertingExceptionsTests
    {
        [Fact]
        public void Calculator_Divided_ShouldReturnErrorDividedByZero()
        {
            //Arrange
            var calculator = new Calculator();

            //Act & Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Divided(10, 0));
        }

        [Fact]
        public void Employee_Salary_ShouldReturnErroLessThanAllowedSalary()
        {
            //Arrange & Act & Assert
            var exception = Assert.Throws<Exception>(() => EmployeeFactory.Create("Giuliano", 250));

            Assert.Equal("Less than allowed salary", exception.Message);
        }
    }
}
