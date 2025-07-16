namespace ConsoleApp3.Helpers;

public static class InputHelper
{
    
    public static string ValidateString(string value, string field)
        => string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException($"'{field}' Не может быть пустым.")
            : value.Trim();

    public static int ValidateInt(string input)
    {
        if (int.TryParse(input, out int result)) 
            return result;
        throw new ArgumentException($"Значение '{input}' не является корректным целым числом.");
    }

    public static int ValidateIndexBooks(int index, int maxCount)
    {
        if (index < 0 || index >= maxCount)
            throw new ArgumentException($"Значение '{index}' не существует в списке книг");
        return index;
    }
    
    public static int RequestNumber()
    {
        while (true)
        {
            Console.WriteLine("Введите число: ");
            string input = Console.ReadLine();
            try
            {
                return ValidateInt(input);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                Thread.Sleep(5000);
            }
        }
    }

    public static int TryRequestIndexBooks(int index, int maxCount)
    {
        while (true)
        {
            try
            {
                return ValidateIndexBooks(index, maxCount);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
    }
}