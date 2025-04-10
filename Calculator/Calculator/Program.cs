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

        if (operatorEntered == true)
        {
            Console.WriteLine("Enter a number: ");
            string userInput1 = Console.ReadLine();
            double firstNumber = double.Parse(userInput1);

            Console.WriteLine("Enter a second number: ");
            string userInput2 = Console.ReadLine();
            double secondNumber = double.Parse(userInput2);

            double result = 0;

            if (operatorSymbol == "+")
                result = firstNumber + secondNumber;
            else if (operatorSymbol == "-")
                result = firstNumber - secondNumber;
            else if (operatorSymbol == "/")
                result = firstNumber / secondNumber;
            else if (operatorSymbol == "x")
                result = firstNumber * secondNumber;

            Console.WriteLine($"The answer to your calculation is: {result}");
        } 
    }
}