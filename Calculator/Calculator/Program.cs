namespace Calculator;

class Program
{
    static void Main(string[] args)
    {
        PrintWelcomeMessage();
        bool wantCalculation;
        do
        {        
            NumberCalculator.PerformOneCalculation();
            Console.WriteLine($"The answer to your calculation is: {NumberCalculator.CalculationAnswer}");
            wantCalculation = RequestCalculcation();
        } while (wantCalculation);
        
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("Welcome to C# Calculator!");
        Console.WriteLine("=========================");
    }
    
    public class NumberCalculator()
    {
        private static string OperatorSymbol
        {
            get;
            set;
        }

        private static int NumberOfNumbers
        {
            get;
            set;
        }

        private static double[] UserNumbers
        {
            get;
            set;
        }

        public static double CalculationAnswer
        {
            get;
            private set;
        }

        public static void PerformOneCalculation()
        {
            ChooseOperatorSymbol();
            ChooseNumberOfNumbers(OperatorSymbol);
            EnterNumbers(NumberOfNumbers);
            CalculateResult(NumberOfNumbers, UserNumbers, OperatorSymbol);
        }

        static void ChooseOperatorSymbol()
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

            OperatorSymbol = userInputOperator;
        }
        
        static void ChooseNumberOfNumbers(string OperatorSymbol)
        {
            Console.WriteLine($"How many numbers do you want to {OperatorSymbol}?");
            string userInput1 = Console.ReadLine();
            NumberOfNumbers = int.Parse(userInput1);
        }

        static void EnterNumbers(int NumberOfNumbers)
        {
            double[] numbers = new double[NumberOfNumbers];

            for (int i = 0; i < NumberOfNumbers; i++)
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
            UserNumbers = numbers;
            
        }

        static void CalculateResult(int NumberOfNumbers, double[] UserNumbers, string OperatorSymbol)
        {
            double result = UserNumbers[0];
            
            for (int i = 1; i < NumberOfNumbers; i++)
            {
                switch (OperatorSymbol)
                {
                    case "+":
                        result += UserNumbers[i];
                        break;
                    case "-":
                        result -= UserNumbers[i];
                        break;
                    case "x":
                        result *= UserNumbers[i];
                        break;
                    case "/":
                        result /= UserNumbers[i];
                        break;
                    default:
                        break;
                }
            }
            CalculationAnswer = result;
        }
    }

    public static bool RequestCalculcation()
    {
        Console.WriteLine("Would you like to calculate something else? (Yes or No)");
        string userAnswer = Console.ReadLine().ToLower();
        return userAnswer == "yes" ? true : false;
    }
    
}