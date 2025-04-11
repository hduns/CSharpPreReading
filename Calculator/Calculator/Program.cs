namespace Calculator;

class Program
{
    static void Main(string[] args)
    {
        PrintWelcomeMessage();
        
        string operatorSymbol = ChooseOperatorSymbol();

        int numberOfNumbers = ChooseNumberOfNumbers(operatorSymbol);

        double calculationResult = PerformOneCalculation(numberOfNumbers, operatorSymbol);

        Console.WriteLine($"The answer to your calculation is: {calculationResult}");
        
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("Welcome to C# Calculator!");
    }

    private static string ChooseOperatorSymbol()
    {
        bool operatorEntered = false;
        string[] operatorArray = new string[] { "+", "-", "x", "/" };

        Console.WriteLine("Please enter a operator (choose from +, -, x, /): ");
        string userInputOperator = Console.ReadLine();

        if (operatorArray.Contains(userInputOperator))
        {
            operatorEntered = true;
        }

        while (!operatorEntered)
        {   
            Console.WriteLine("Please enter a operator (+, -, x, /)");
            userInputOperator = Console.ReadLine();
            if (operatorArray.Contains(userInputOperator))
            {
                operatorEntered = true;
            }
            else
                operatorEntered = false;
        }

        return userInputOperator;
    }

    public static int ChooseNumberOfNumbers(string operatorSymbol)
    {
        Console.WriteLine($"How many numbers do you want to {operatorSymbol}?");
        string userInput1 = Console.ReadLine();
        return int.Parse(userInput1);
    }

    public static double PerformOneCalculation(int numberOfNumbers, string operatorSymbol)
    {
        double[] numbers = new double[numberOfNumbers];

        for (int i = 0; i < numberOfNumbers; i++)
        {
            Console.WriteLine("Enter a number: ");
            string userInput2 = Console.ReadLine();
            double number = double.Parse(userInput2);
            numbers[i] = number;
        }
            
        foreach (double number in numbers)
        {
            Console.WriteLine(number);
        }
            
        double result = numbers[0];

        for (int i = 1; i < numberOfNumbers; i++)
        {
            switch (operatorSymbol)
            {
                case "+":
                    result += numbers[i];
                    break;
                case "-":
                    result -= numbers[i];
                    break;
                case "x":
                    result *= numbers[i];
                    break;
                case "/":
                    result /= numbers[i];
                    break;
                default:
                    break;
            }
        }
        return result;
    }
    
}