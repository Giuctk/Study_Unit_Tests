using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.Test
{
    public class AssertNumbersTestes
    {
        [Fact]
        public void Calculator_Sum_ShouldBeEqual()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Sum(1, 2);

            //Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Calculator_Sum_ShouldNotBeEqual()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Sum(1.13123123123, 2.23123123);

            //Assert
            Assert.NotEqual(3.3, result, 1);

        }
    }
}
