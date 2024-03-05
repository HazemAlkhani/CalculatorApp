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
            
            var mockDatabaseService = new Mock<IDatabaseService>(); 
            mockDatabaseService.Setup(service => service.LogOperation(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<string>(), It.IsAny<double>()));
            
            
            var calculator = new Calculator(mockDatabaseService.Object); 
            double num1 = 2;
            double num2 = 3;

           
            double result = calculator.Add(num1, num2);

            
            Assert.That(result, Is.EqualTo(5)); 
            
            
            mockDatabaseService.Verify(service => service.LogOperation(num1, num2, "+", 5), Times.Once);
        }
    }
}