using System;
using System.Data.SqlClient;

namespace CalculatorApp
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void LogOperation(double n1, double n2, string operation, double result)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Calculation (Number1, Operation, Number2, Result, OperationTime) " +
                            "VALUES (@Number1, @Operation, @Number2, @Result, @OperationTime)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Number1", n1);
                    command.Parameters.AddWithValue("@Operation", operation);
                    command.Parameters.AddWithValue("@Number2", n2);
                    command.Parameters.AddWithValue("@Result", result);
                    command.Parameters.AddWithValue("@OperationTime", DateTime.Now);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
    
}