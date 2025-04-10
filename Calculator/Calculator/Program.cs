namespace Calculator;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to C# Calculator!");
        Console.WriteLine("Enter a number: ");
        string firstNumber = Console.ReadLine();
        Console.WriteLine("Enter a second number: ");
        string secondNumber = Console.ReadLine();
        Console.WriteLine($"{firstNumber} x {secondNumber} = {int.Parse(firstNumber) * int.Parse(secondNumber)}");
        Console.WriteLine($"{firstNumber} x {secondNumber} = {int.Parse(firstNumber) * int.Parse(secondNumber)}");
    }
}