using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.Test
{
    public class AssertStringsTests
    {
        [Fact]
        public void StringTools_JoinNames_ReturnFullName()
        {
            //Arrange
            var sut = new StringsTools();

            //Act
            var fullName = sut.Join("Giuliano", "Tacioli");

            //Assert
            Assert.Equal("Giuliano Tacioli", fullName);
        }

        [Fact]
        public void StringsTools_JoinNames_ShouldIgnoreCase()
        {

            //Arrange
            var sut = new StringsTools();

            //Act
            var fullName = sut.Join("Giuliano", "Tacioli");

            //Assert
            Assert.Equal("Giuliano Tacioli", fullName, true);
        }

        [Fact]
        public void StringsTools_JoinNames_ShouldContainSnippet()
        {
            //Arrange
            var sut = new StringsTools();

            //Act
            var fullName = sut.Join("Giuliano", "Tacioli");

            //Assert
            Assert.Contains("ulian", fullName);
        }

        [Fact]
        public void StringsTools_JoinNames_ShouldStartWith()
        {
            //Arrange
            var sut = new StringsTools();

            //Act
            var fullName = sut.Join("Giuliano", "Tacioli");

            //Assert
            Assert.StartsWith("Giu", fullName);
        }

        [Fact]
        public void StringsTools_JoinNames_ShouldEndsWith()
        {
            //Arrange
            var sut = new StringsTools();

            //Act
            var fullName = sut.Join("Giuliano", "Tacioli");

            //Assert
            Assert.EndsWith("oli", fullName);
        }

        [Fact]
        public void StringsTools_JoinNames_ValidateRegularExpression()
        {
            //Arrange
            var sut = new StringsTools();

            //Act
            var fullName = sut.Join("Giuliano", "Tacioli");

            //Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", fullName);
        }
    }
}
