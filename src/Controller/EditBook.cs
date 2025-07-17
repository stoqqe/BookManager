using ConsoleApp3.Helpers;
namespace ConsoleApp3.EditBook;

public static class BookEditor
{
    public static void EditBookHandler(List<Book> books)
    {
        while (true)
        {
            Console.WriteLine("+--------------------------| Edit Book |---------------------------------+ \n" +
                              "| [1] Изменить название книги    | [2] Изменить автора книги             | \n" +
                              "| [3] Изменить жанр книги        | [4] Изменить количество страниц книги | \n" +
                              "| [5] Изменить год выпуска книги | [0] Вернутся в меню                   | \n" +
                              "+------------------------------------------------------------------------+ \n");
            Console.WriteLine("+---------------------------+ \n" +
                              "| Введите оператор из [0-5] | \n" +
                              "+---------------------------+ \n");
            int choice = InputHelper.RequestInt("Оператор");
            int index = InputHelper.RequestIndexBooks(books.Count);
            switch (choice)
            {
                case 0:
                    return;
                    break;
                case 1:
                    ChangeString(books, index, "название");
                    break;
                case 2:
                    ChangeString(books, index, "автора");
                    break;
                case 3:
                    ChangeString(books, index, "жанр");
                    break;
                case 4:
                    ChangeInt(books, index, "количество страниц");
                    break;
                case 5:
                    ChangeInt(books, index, "год выпуска");
                    break;
            }
        }
    }

    public static void ChangeString(List<Book> books, int index, string choice)
    {
        string newNameof = InputHelper.RequestString(choice);
        switch (choice)
        {
            case "название":
                books[index].Rename(newNameof);
                break;
            case "автора":
                books[index].ChangeAuthor(newNameof);
                break;
            case "жанр":
                books[index].ChangeGenre(newNameof);
                break;
        }
    }

    public static void ChangeInt(List<Book> books, int index, string choice)
    {
        int newNameof = InputHelper.RequestInt(choice);
        switch (choice)
        {
            case "количество страниц":
                books[index].ChangeNumberOfPages(newNameof);
                break;
            case "год выпуска":
                books[index].ChangeYearOfIssue(newNameof);
                break;
        }
    }
    
    public static Book CreateNewBook()
    {
        string name = InputHelper.RequestString("Название книги");
        string author = InputHelper.RequestString("Автора книги");
        string genre = InputHelper.RequestString("Жанр книги");
        int numberOfPages = InputHelper.RequestInt("Количество страниц");
        int yearOfIssue = InputHelper.RequestInt("Год выпуска");
        bool available = InputHelper.RequestBool();
        
        return new Book(name, author, genre, numberOfPages, yearOfIssue, available);
    }
}