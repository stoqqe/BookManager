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
    
    public static int RequestInt(string field = "Число")
    {
        while (true)
        {
            Console.WriteLine($"Введите '{field}': ");
            string input = Console.ReadLine();
            try
            {
                return ValidateInt(input);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                Thread.Sleep(2500);
            }
        }
    }

    public static string RequestString(string field = "Значение")
    {
        while (true)
        {
            Console.WriteLine($"Введите '{field}'");
            string input = Console.ReadLine();
            try
            {
                return ValidateString(input, field);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                Thread.Sleep(2500);
            }
        }
    }

    public static bool RequestBool(string fieldTrue = "Доступна", string fieldFalse = "Не доступна")
    {
        while (true)
        {
            Console.WriteLine($"Введите чтобы пометить как | w - {fieldTrue} | e - {fieldFalse}");
            string input = RequestString("[w/e]");
            string choice = input.ToLowerInvariant();
            if (choice == "w")
                return true;
            if (choice == "e")
                return false;
            Console.WriteLine("Ошибка: введите 'w' или 'e'. Попробуйте снова.");
        }
    }

    public static int RequestIndexBooks(int maxCount, string field = "Книги")
    {
        while (true)
        {
            Console.WriteLine($"Введите индекс '{field}'");
            int index = RequestInt("Индекс");
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