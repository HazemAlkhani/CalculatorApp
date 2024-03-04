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
           
            var calculator = new Calculator("Server=ASUS-ROG,1433;Database=CalculatorDB;User Id=sa;Password=700170;"); 
            double num1 = 2;
            double num2 = 3;

            
            double result = calculator.Add(num1, num2);

            // Assert
            Assert.AreEqual(5, result);
        }

        
    }
}