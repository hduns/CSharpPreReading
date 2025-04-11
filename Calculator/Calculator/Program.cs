namespace Calculator;

class Program
{
    static void Main(string[] args)
    {
        PrintWelcomeMessage();
        string operatorSymbol = ChooseOperatorSymbol();
        int numberOfNumbers = ChooseNumberOfNumbers(operatorSymbol);
        double[] userNumbers = EnterNumbers(numberOfNumbers);
        double calculationResult = PerformOneCalculation(numberOfNumbers, operatorSymbol, userNumbers);
        

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

    public static double[] EnterNumbers(int numberOfNumbers)
    {
        double[] numbers = new double[numberOfNumbers];

        for (int i = 0; i < numberOfNumbers; i++)
        {
            Console.WriteLine("Please enter a number: ");
            string userInput2 = Console.ReadLine();
            double number;

            if (double.TryParse(userInput2, out number))
            {
                numbers[i] = number;
            }
            else
            {
                Console.WriteLine($"{userInput2} is not a number.");
                i -= 1;
            }

        }
        return numbers;
    }

    public static double PerformOneCalculation(int numberOfNumbers, string operatorSymbol, double[] userNumbers)
    {
       
        double result = userNumbers[0];

        for (int i = 1; i < numberOfNumbers; i++)
        {
            switch (operatorSymbol)
            {
                case "+":
                    result += userNumbers[i];
                    break;
                case "-":
                    result -= userNumbers[i];
                    break;
                case "x":
                    result *= userNumbers[i];
                    break;
                case "/":
                    result /= userNumbers[i];
                    break;
                default:
                    break;
            }
        }
        return result;
    }
    
}