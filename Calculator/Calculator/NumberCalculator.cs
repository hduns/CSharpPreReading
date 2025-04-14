namespace Calculator;

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
            int number;
            
            do
            {
                Console.WriteLine($"How many numbers do you want to {OperatorSymbol}?");
            } while (!int.TryParse(Console.ReadLine(), out number));
            NumberOfNumbers = number;
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
            
                switch (OperatorSymbol)
                {
                    case "+":
                        result = UserNumbers.Sum();
                        break;
                    case "-":
                        result = UserNumbers.Aggregate((accumulator, currentValue) => accumulator - currentValue);
                        break;
                    case "x":
                        result = UserNumbers.Aggregate((accumulator, currentValue) => accumulator * currentValue);
                        break;
                    case "/":
                        result = UserNumbers.Aggregate((accumulator, currentValue) => accumulator / currentValue);
                        break;
                    default:
                        break;
                }
            CalculationAnswer = result;
        }

        public static void LogCalculationInTextFile(string path)
        {
            string calculationBody = "";
            foreach (double number in UserNumbers)
            {
                    calculationBody += " " + number + " " + OperatorSymbol;
            }

            calculationBody = calculationBody.Trim().Substring(0, calculationBody.Length - 2);

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"{calculationBody} = {CalculationAnswer}");
                sw.WriteLine();
            }

        }
    }

