using ConsoleApp3.Helpers;
using ConsoleApp3.EditBook;
namespace ConsoleApp3;

class ControllerBook
{
    private const int NumberOfObjectsPerPage = 4;
    private static readonly int[] Operators = { 1, 2, 3, 4, 5, 6, 7 };
    private int _page = 1;
    private int _maxPages = 0;
    private bool _programEnd = false;
    
    private List<Book> _books = new List<Book>
    {
        new Book("1984", "George Orwell", "Dystopia", 328, 1949),
        new Book("To Kill a Mockingbird", "Harper Lee", "Classic", 281, 1960),
        new Book("The Hobbit", "J. R. R. Tolkien", "Fantasy", 310, 1937),
        new Book("Pride and Prejudice", "Jane Austen", "Romance", 279, 1813),
        new Book("Moby‑Dick", "Herman Melville", "Adventure", 585, 1851, false),
        new Book("War and Peace", "Leo Tolstoy", "Historical", 1225, 1869),
        new Book("The Great Gatsby", "F. Scott Fitzgerald", "Classic", 180, 1925),
        new Book("Crime and Punishment", "Fyodor Dostoevsky", "Psychological", 671, 1866),
        new Book("Don Quixote", "Miguel de Cervantes", "Satire", 863, 1605, false),
        new Book("Brave New World", "Aldous Huxley", "Dystopia", 268, 1932),
        new Book("One Hundred Years of Solitude", "Gabriel García Márquez", "Magical Realism", 417, 1967),
        new Book("The Catcher in the Rye", "J. D. Salinger", "Coming‑of‑age", 214, 1951)
    };
    
    public void Start()
    {
        while (!_programEnd)
        {
            Console.Clear();
            RecalculateMaxPages();
            Console.WriteLine($"Библиотека книг Выберите действие: \n" +
                              "[1] Отображить полный список книг. [2] Отображить список книг страницами. \n" +
                              "[3] Изменить данные книги.         [4] Пометить книгу доступной. \n" +
                              "[5] Пометить книгу недоступной.    [6] Добавить книгу. \n" +
                              "[7] Удалить книгу. \n" +
                              "[0] Выйти из программы. \n" +
                              "[-] Введите оператор из \"[]\" слева от нужного вам действия: ");
            int choice = InputHelper.RequestInt("Оператор");
            SelectionHandler(choice);
        }
    }

    private void SelectionHandler(int choice)
    {
        switch (choice)
        {
            case 1:
                ShowAllBooks();
                break;
            case 2:
                ShowByPages();
                break;
            case 3:
                    BookEditor.EditBookHandler(_books);
                break;
            case 4 or 5:
                ToogleBookStatus(choice);
                break;
            case 6:
                _books.Add(BookEditor.CreateNewBook());
                EnterToContinue();
                break;
            case 0:
                _programEnd = true;
                break;
            default:
                Console.WriteLine("Неизвстеный ввод, повторите попытку");
                break;
        }
    }
    
    

    private void ShowAllBooks()
    {
        for (int i = 0; i < _books.Count; i++)
        {
            Console.WriteLine($"{i}|{_books[i].ToString()}");
        }
        EnterToContinue();
    }

    private void ShowByPages()
    {
        int start = (_page - 1) * NumberOfObjectsPerPage;
        int end = Math.Min(start + NumberOfObjectsPerPage, _books.Count);

        if (start >= _books.Count || _page <= 0)
        {
            Console.WriteLine("Такой страницы не существует.");
            ContinueShowByPages();
        }
        
        Console.Clear();
        Console.WriteLine($"Страница {_page} из {_maxPages}\n");
        for (int i = start; i < end; i++)
        {
            Console.WriteLine($"{i}|{_books[i].ToString()}");
        }
        ContinueShowByPages();
    }

    private void ContinueShowByPages()
    {
        Console.WriteLine($"Страница - {_page}");
        Console.WriteLine("[z] Назад  |  [c] Вперёд  |  [0] Выход из страниц |  [1–7] Действие");
        string input = Console.ReadLine();
        string choice = input.ToLowerInvariant();
        switch (choice)
        {
            case "z":
                if (_page > 1) _page--;
                ShowByPages();
                break;
            case "c":
                if (_page < _maxPages) _page++;
                ShowByPages();
                break;
            case "q":
                return;
            default:
                try
                {
                    int intChoice = InputHelper.ValidateInt(input);
                    if (Operators.Contains(intChoice)) SelectionHandler(intChoice);
                    else EnterToContinue();
                }
                catch (ArgumentException e)
                {
                    Thread.Sleep(5000);
                    Console.WriteLine(e);
                }
                break;
        }
    }

    private void ToogleBookStatus(int handler)
    {
        Console.WriteLine("Введите номер книги из списка (индекс)");
        int index = InputHelper.RequestIndexBooks(_books.Count);
        switch (handler)
        {
            case 4:
                _books[index].Return();
                break;
            case 5:
                _books[index].Borrow();
                break;
            default:
                _books[index].ToggleAvailability();
                break;
        }
    }
    
    private int RecalculateMaxPages() => 
        _maxPages = (_books.Count + NumberOfObjectsPerPage - 1) / NumberOfObjectsPerPage;

    private void EnterToContinue()
    {
        Console.WriteLine("Нажмите 'Enter' чтобы продолжить или введите [1-7] чтобы совершить действие");
        string choice = Console.ReadLine();
        try
        {
            int intChoice = InputHelper.ValidateInt(choice);
            SelectionHandler(intChoice);
        }
        catch (ArgumentException e)
        {
            return;
        }
    }
}