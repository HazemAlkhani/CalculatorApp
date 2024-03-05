
using System.Data.SqlClient;

using System;

namespace CalculatorApp
{
    public class Calculator : ICalculator
    {
        private readonly IDatabaseService _databaseService;

        public Calculator(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            _databaseService.LogOperation(n1, n2, "+", result);
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            _databaseService.LogOperation(n1, n2, "-", result);
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            _databaseService.LogOperation(n1, n2, "*", result);
            return result;
        }

        public double Divide(double n1, double n2)
        {
            if (n2 == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            double result = n1 / n2;
            _databaseService.LogOperation(n1, n2, "/", result);
            return result;
        }

    }   
}