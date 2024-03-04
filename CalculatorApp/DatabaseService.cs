using System;
using System.Data.SqlClient;

namespace CalculatorApp
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
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