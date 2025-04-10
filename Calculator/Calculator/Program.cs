namespace Calculator;

class Program
{
    static void Main(string[] args)
    {
       
        Console.WriteLine("Welcome to C# Calculator!");
        bool operatorEntered = false;
        string[] operatorArray = new string[] { "+", "-", "x", "/" };

        Console.WriteLine("Please enter a operator (choose from +, -, x, /): ");
        string operatorSymbol = Console.ReadLine();

        if (operatorArray.Contains(operatorSymbol))
        {
            operatorEntered = true;
        }

        while (!operatorEntered)
        {   
            Console.WriteLine("Please enter a operator (+, -, x, /)");
            operatorSymbol = Console.ReadLine();
            if (operatorArray.Contains(operatorSymbol))
            {
                operatorEntered = true;
            }
            else
                operatorEntered = false;
        }
        
        Console.WriteLine($"How many numbers do you want to {operatorSymbol}?");
        string userInput1 = Console.ReadLine();
        int numberOfNumbers = int.Parse(userInput1);

        if (operatorEntered == true)
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

            Console.WriteLine($"The answer to your calculation is: {result}");
        } 
    }
}