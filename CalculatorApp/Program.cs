using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator App!");

            try
            {
                // Prompt the user for input
                Console.Write("Enter the first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter the operator (+, -, *, /): ");
                char op = Convert.ToChar(Console.ReadLine());

                Console.Write("Enter the second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double result = 0;

                // Perform calculations based on the operator
                Calculator calculator = new Calculator("Server=ASUS-ROG,1433;Database=CalculatorDB;User Id=sa;Password=700170;");
                switch (op)
                {
                    case '+':
                        result = calculator.Add(num1, num2);
                        break;
                    case '-':
                        result = calculator.Subtract(num1, num2);
                        break;
                    case '*':
                        result = calculator.Multiply(num1, num2);
                        break;
                    case '/':
                        if (num2 != 0)
                            result = calculator.Divide(num1, num2);
                        else
                            Console.WriteLine("Cannot divide by zero.");
                        break;
                    default:
                        Console.WriteLine("Invalid operator entered.");
                        break;
                }

                Console.WriteLine($"Result of {num1} {op} {num2} = {result}");

                // Log the operation
                calculator.LogOperation(num1, num2, op.ToString(), result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter numeric values.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input exceeds the valid range of values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
