namespace CalculatorApp
{
    public interface IDatabaseService
    {
        void LogOperation(double n1, double n2, string operation, double result);
    }
}