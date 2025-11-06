using System.Collections.ObjectModel;
using Coursera.Shared;

namespace Coursera.Course2_IntroductionToPrograming;

internal enum result
{
    teste1,
    
}
public class BookStore
{
    private readonly List<string> _bookList = new List<string>(MaxBooks);
    private const int MaxBooks = 5;


    public BookStore(){}
    

    public ReadOnlyCollection<string> GetBooks()
    {
        return _bookList.AsReadOnly();
    }

    public bool AddBook(string bookName)
    {
        if (_bookList.Count >= MaxBooks)
        {
            return false;
        }
        
        _bookList.Add(bookName);
        _bookList.Sort(StringComparer.OrdinalIgnoreCase);
        return true;
    }

    public bool RemoveBook(string bookName)
    {
        var removeCOunt = _bookList.RemoveAll(b => string.Equals(b, bookName.Trim(),StringComparison.OrdinalIgnoreCase));
        if (removeCOunt > 0)
            return true;
        return false;
    }
}

public static class BookStoreConsoleUI
{
    
    
    private const string MsgInvalidInput = "Invalid input. Please try again.";
    private const string MsgNoBooks = "No books to show.";
    private const string MsgRemoved = "Book successfully removed.";
    private const string MsgRemoveError = "No matching book found.";
    private const string MsgMaxReached = "Maximum number of books reached.";

    
    public static void MainLoop()
    {
        Console.WriteLine("------BookStore APP------");
        BookStore bookStore = new BookStore();
        
        while (true)
        {
            Console.WriteLine("1-Add Book");
            Console.WriteLine("2-Remove Book");
            Console.WriteLine("3-Show Books");
            Console.WriteLine("4-Leave\n");
            Console.Write("Option:");
            int opt;
            
            if (int.TryParse(Console.ReadLine(), out opt))
            {
                switch (opt)
                {
                    case 1:
                        bool result = bookStore.AddBook(Reader.ReadLineImp(MsgInvalidInput,"BookName:"));
                        if (!result)
                        {
                            Console.WriteLine(MsgMaxReached);
                        }
                        break;
                    case 2:
                        bool res = bookStore.RemoveBook(Reader.ReadLineImp(MsgInvalidInput,"BookName:"));
                        if (res)
                        {
                            Console.WriteLine(MsgRemoved);
                        }
                        else
                        {
                            Console.WriteLine(MsgRemoveError);
                        }
                        break;
                    case 3:
                        ShowBooks(bookStore.GetBooks());
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Wrong Input, Try Again!!\n");
                        break;
                }
                
                Console.WriteLine(LineSeparator.lineSeparator);
                
            }
            else
            {
                Console.WriteLine("Wrong Input, Try Again!!\n");
            }

        }
        
        
    }

    public static void ShowBooks(ReadOnlyCollection<string> books)
    {

        if (books.Count == 0)
        {
            Console.WriteLine(MsgNoBooks);
            return;
        }

        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine((i+1) + " - " + books[i]);
        }
        
    }
    
    
    
}