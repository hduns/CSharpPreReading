
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
                Console.Clear();
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
                Console.WriteLine($"The answer to your calculation is: {dC1.NewDate.ToLongDateString()}");
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
    