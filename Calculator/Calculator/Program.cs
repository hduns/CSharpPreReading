namespace Calculator;

class Program
{
    static void Main(string[] args)
    {
        PrintWelcomeMessage();
        bool wantCalculation;
        do
        {
            string calculator = ChooseCalculator();
            Console.WriteLine($"You have chosen the {calculator} calculator!\n");
            if (calculator == "Number")
            {
                NumberCalculator.PerformOneCalculation();
                Console.WriteLine($"The answer to your calculation is: {NumberCalculator.CalculationAnswer}");
            } else if (calculator == "Date")
            {
                Console.WriteLine("Please enter a date in the format DD/MM/YYYY: ");
                DateTime userDateTime = DateTime.Parse(Console.ReadLine());
                string dateCalculationOption = ChooseDateCalculationOption();
                Console.WriteLine($"You have chosen to {dateCalculationOption}.");
                // User inputs date information for calculation
                Console.WriteLine($"Please enter the days you would like to {dateCalculationOption}. You can enter 0 if you wish.");
                int userDays = int.Parse(Console.ReadLine());
                Console.WriteLine($"Please enter the months you would like to {dateCalculationOption}:");
                int userMonths = int.Parse(Console.ReadLine());
                Console.WriteLine($"Please enter the years you would like to {dateCalculationOption}:");
                int userYears = int.Parse(Console.ReadLine());
                // Instance of DateCalculator intantitized
                DateCalculator dC1 = new DateCalculator(userDateTime, userDays, userMonths, userYears);
                if (dateCalculationOption == "Add")
                    dC1.Add();
                else
                    dC1.Subtract();
                Console.WriteLine($"The answer to your calculation is: {dC1.NewDate}");
            }
            wantCalculation = RequestCalculcation();
        } while (wantCalculation);
    }

    private static string ChooseCalculator()
    {
        bool choosenCalculator = false;
        string calculatorChoice = "";

        while (choosenCalculator == false)
        {
            Console.WriteLine("Which calculator do you want? \n 1) Numbers \n 2) Dates \nChoose Number");
            string userChoice = Console.ReadLine();

            if (int.TryParse(userChoice, out int choice))
            {
                if (choice == 1)
                {
                    calculatorChoice = "Number";
                    choosenCalculator = true;
                }
                else if (choice == 2)
                {
                    calculatorChoice = "Date";
                    choosenCalculator = true;
                }
                else
                {
                    Console.WriteLine("Sorry we don't have that option.");
                }
            }
            else
            {
                Console.WriteLine($"{userChoice} is not a valid number. ");
            }
        }
        return calculatorChoice;
    }

    private static string ChooseDateCalculationOption()
    {
        bool dateCalculationOptionChoosen = false;
        string dateCalculationChoice = "";

        while (!dateCalculationOptionChoosen)
        {
            Console.WriteLine("Would you like to add or subtract from your date? Choose option: \n1) Add \n2) Subtract");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int choice))
            {
                if (choice == 1)
                {
                    dateCalculationChoice = "Add";
                    dateCalculationOptionChoosen = true;
                } 
                else if (choice == 2)
                {
                    dateCalculationChoice = "Subtract";
                    dateCalculationOptionChoosen = true;
                }
                else
                {
                    Console.WriteLine("Sorry we don't have that option");
                }
                
            }
            else
            {
                Console.WriteLine($"{userInput} is not a valid option.");
            }
        }
        return dateCalculationChoice;
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("Welcome to C# Calculator!");
        Console.WriteLine("=========================");
    }

    public static bool RequestCalculcation()
    {
        Console.WriteLine("Would you like to calculate something else? (Yes or No)");
        string userAnswer = Console.ReadLine().ToLower();
        return userAnswer == "yes" ? true : false;
    }
    
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

public class DateCalculator
{
    private DateTime OriginalDate
    {
        get;
        set;
    }
    
    public DateTime NewDate
    {
        get;
        private set;
    }

    private int UserDays
    {
        get;
        set;
    }
    
    private int UserMonths
    {
        get;
        set;
    }
    
    private int UserYears
    {
        get;
        set;
    }

    public DateCalculator(DateTime originalDate, int usersDays, int userMonths, int userYears)
    {
        OriginalDate = originalDate;
        NewDate = originalDate;
        UserDays = usersDays;
        UserMonths = userMonths;
        UserYears = userYears;
    }

    public void Add()
    {
        NewDate = NewDate.AddDays(UserDays);
        NewDate = NewDate.AddMonths(UserMonths);
        NewDate = NewDate.AddYears(UserYears);
    }
    
    public void Subtract()
    {
        NewDate = NewDate.AddDays(-UserDays);
        NewDate = NewDate.AddMonths(-UserMonths);
        NewDate= NewDate.AddYears(-UserYears);
    }

}