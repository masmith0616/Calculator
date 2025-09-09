using System;

//Main entry
bool exit = false;
do
{
    Console.WriteLine("Input basic equation i.e. '2 + 1;");
    string equation = Console.ReadLine();
    //Add error handling for null, bad format, bad arguements

    EquationBuilder(equation);

    Console.WriteLine("Again? Type yes or no.");
    string again = Console.ReadLine();
    again.ToLower();

    if (again != "yes" && again != "y")
    {
        exit = true;
    }

} while (exit == false);


//Parent method
static void EquationBuilder(string eq)
{
    //Part 1. Convert string to string[]
    string[] elements = eq.Trim().Split(" ");
    CharConversion(elements);
}

//Part 2. Convert numbers to int and identify operator
static void CharConversion(string[] elements)
{
    string mathSymbol = "";
    int[] numbers = new int [elements.Length];
    for (int i = 0; i < elements.Length; i++)
    {
        if (!int.TryParse(elements[i], out int num))
        {
            mathSymbol = elements[i];
        }
        else if(i <= numbers.Length - 1)
        {
            numbers[i] = num;
        }
    }
    Console.WriteLine(ConductMath(numbers, mathSymbol));
}

//Part 3. Conduct Math based on mathSymbol
static string ConductMath(int[] numbers, string mathSymbol)
{
    int result = 0;
    bool error = false;
    switch (mathSymbol)
    {
        case "+":
            result = numbers.Sum();
            break;
        case "-":
            result = numbers.First() - numbers.Last();
            break;
        case "*":
            result = numbers.First() * numbers.Last();
            break;
        case "/":
            result = numbers.First() / numbers.Last();
            break;
        case "%":
            result = numbers.First() % numbers.Last();
            break;
        default:
            Console.WriteLine($"{mathSymbol} not recognized at this time. Try again later");
            error = true;
            break;

    }
    return !error ? result.ToString(): "Calculation not completed.";
}

