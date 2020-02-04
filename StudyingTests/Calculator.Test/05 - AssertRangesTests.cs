using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.Test
{
    public class AssertRangesTests
    {
        [Theory]
        [InlineData(700)]
        [InlineData(1500)]
        [InlineData(2000)]
        [InlineData(7500)]
        [InlineData(8000)]
        [InlineData(15000)]
        public void Employee_Salary_SalaryRangesMustRespectProfessionalLevel(double salary)
        {
            //Arrange & Act
            var employee = new Employee("Giuliano", salary);

            //Assert
            if (employee.ProfessionalLevel == EProfessionalLevel.Jr)
                Assert.InRange(employee.Salary, 500, 1999);

            if (employee.ProfessionalLevel == EProfessionalLevel.Pl)
                Assert.InRange(employee.Salary, 2000, 7999);

            if (employee.ProfessionalLevel == EProfessionalLevel.Sr)
                Assert.InRange(employee.Salary, 8000, double.MaxValue);

            Assert.NotInRange(employee.Salary, 0, 499);
        }
    }
}
