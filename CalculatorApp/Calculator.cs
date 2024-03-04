using System;
using System.Data.SqlClient;

namespace CalculatorApp
{
    public class Calculator : ICalculator
    {
        private readonly string _connectionString;

        public Calculator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            LogOperation(n1, n2, "+", result); // Pass the result parameter
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            LogOperation(n1, n2, "-", result); // Pass the result parameter
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            LogOperation(n1, n2, "*", result); // Pass the result parameter
            return result;
        }

        public double Divide(double n1, double n2)
        {
            if (n2 == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            double result = n1 / n2;
            LogOperation(n1, n2, "/", result); // Pass the result parameter
            return result;
        }


        public void LogOperation(double n1, double n2, string op, double result)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Calculation (Number1, Operation, Number2, Result, OperationTime) " +
                               "VALUES (@Number1, @Operation, @Number2, @Result, @OperationTime)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Number1", n1);
                command.Parameters.AddWithValue("@Operation", op);
                command.Parameters.AddWithValue("@Number2", n2);
                command.Parameters.AddWithValue("@Result", result);
                command.Parameters.AddWithValue("@OperationTime", DateTime.Now);
                command.ExecuteNonQuery();
            }
        }

    }
}