using Moq;
using NUnit.Framework;
using CalculatorApp;

namespace CalculatorApp.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_WhenCalled_ReturnsCorrectSum()
        {
            // Arrange
            var mockDatabaseService = new Mock<DatabaseService>();
            mockDatabaseService.Setup(service => service.LogOperation(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<string>(), It.IsAny<double>()));
            
            var calculator = new Calculator(mockDatabaseService.Object); // Adjust Calculator to use IDatabaseService
            double num1 = 2;
            double num2 = 3;

            // Act
            double result = calculator.Add(num1, num2);

            // Assert
            Assert.That(result, Is.EqualTo(5));
            mockDatabaseService.Verify(service => service.LogOperation(num1, num2, "+", 5), Times.Once);
        }
    }
}