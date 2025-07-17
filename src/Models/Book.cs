using ConsoleApp3.Helpers;
public class Book : IEquatable<Book>
{
    public string Name          { get; private set; }
    public string Author        { get; private set; }
    public string Genre         { get; private set; }
    public int    NumberOfPages { get; private set; }
    public int    YearOfIssue   { get; private set; }
    public bool   Available     { get; private set; }

    public Book(string name, string author, string genre,
                int numberOfPages, int yearOfIssue, bool available = true)
    {
        Rename(name);
        ChangeAuthor(author);
        ChangeGenre(genre);
        ChangeNumberOfPages(numberOfPages);
        ChangeYearOfIssue(yearOfIssue);
        Available = available;
    }
    
    public void Borrow()  { if (Available) Available = false; }
    public void Return()  { if (!Available) Available = true; }
    public void ToggleAvailability() => Available = !Available;
    
    public void Rename(string newName)
        => Name = InputHelper.ValidateString(newName, nameof(Name));

    public void ChangeAuthor(string newAuthor)
        => Author = InputHelper.ValidateString(newAuthor, nameof(Author));

    public void ChangeGenre(string newGenre)
        => Genre = InputHelper.ValidateString(newGenre, nameof(Genre));

    public void ChangeNumberOfPages(int pages)
    {
        if (pages <= 0) throw new ArgumentOutOfRangeException(nameof(pages));
        NumberOfPages = pages;
    }

    public void ChangeYearOfIssue(int year)
    {
        int currentYear = DateTime.UtcNow.Year;
        if (year < 1450 || year > currentYear)
            throw new ArgumentOutOfRangeException(nameof(year));
        YearOfIssue = year;
    }
    
    

    public override string ToString()
        => $"{Name,-30} | {Author,-30} | {Genre,-30} | {YearOfIssue,4} | {(Available ? "Доступна" : "Не доступна")}";

    public bool Equals(Book? other)
        => other is not null && Name == other.Name && Author == other.Author;
}
