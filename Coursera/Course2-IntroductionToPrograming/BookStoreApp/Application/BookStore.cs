using System.Collections.ObjectModel;
using Coursera.Shared;
using Coursera.Course2_IntroductionToPrograming.BookStoreApp.Domain;

public class BookStore
{
    private readonly List<Book> _bookList = new List<Book>(MaxBooks);
    private const int MaxBooks = 5;
    private const int MaxBorrowedBooks = 3;

    public BookStore()
    {
        
    }
    

    public ReadOnlyCollection<Book> GetBooks()
    {
        return _bookList.AsReadOnly();
    }

    public bool AddBook(string bookName)
    {
        if (_bookList.Count >= MaxBooks)
        {
            return false;
        }
        
        _bookList.Add(new Book(bookName));
        return true;
    }

    public bool RemoveBook(string bookName)
    {
        var removeCOunt = _bookList.RemoveAll(b => string.Equals(b.Name, bookName.Trim(),StringComparison.OrdinalIgnoreCase));
        if (removeCOunt > 0)
            return true;
        return false;
    }

    public bool SearchBook(string bookName)
    {
        var foundNumber = _bookList.FindAll(b => string.Equals(b.Name , bookName.Trim(),StringComparison.OrdinalIgnoreCase));
        if (foundNumber.Count > 0)
        {
            return true;
        }
        return false;
    }

    public string BorrowBook(string bookName,User user)
    {

        if (user.BorrowedBooks == MaxBorrowedBooks)
        {
            return "User has borrowed the max Books possible!!";
        }
        
        for (int i = 0; i < _bookList.Count; i++)
        {
            if (string.Equals(_bookList[i].Name, bookName.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                _bookList[i].BorrowBook();
                user.AddBorrowedBook();
            }
        }

        return "Borrowed Books Successfully";
    }
}
    
