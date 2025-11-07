using System.Collections.ObjectModel;
using Coursera.Course2_IntroductionToPrograming.BookStoreApp.Domain;
using Coursera.Shared;

namespace Coursera.Course2_IntroductionToPrograming.BookStoreApp.Presentation;

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
        global::BookStore bookStore = new global::BookStore();

        while (true)
        {
            Console.WriteLine("1-Add Book");
            Console.WriteLine("2-Remove Book");
            Console.WriteLine("3-Show Books");
            Console.WriteLine("4-Search Book");
            Console.WriteLine("5-Borrow Book");
            Console.WriteLine("6-Leave\n");
            Console.Write("Option:");
            int opt;

            if (int.TryParse(Console.ReadLine(), out opt))
            {
                switch (opt)
                {
                    case 1:
                        bool result = bookStore.AddBook(Reader.ReadLineImp(MsgInvalidInput, "BookName:"));
                        if (!result)
                        {
                            Console.WriteLine(MsgMaxReached);
                        }

                        break;
                    case 2:
                        bool res = bookStore.RemoveBook(Reader.ReadLineImp(MsgInvalidInput, "BookName:"));
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
                        if (bookStore.SearchBook(Reader.ReadLineImp(MsgInvalidInput, "BookName:")))
                        {
                            Console.WriteLine("Book Found!");
                        }
                        else
                        {
                            Console.WriteLine("Book Not Found!");
                        }

                        ;
                        break;
                    case 5:
                        Console.WriteLine(bookStore.BorrowBook(Reader.ReadLineImp(MsgInvalidInput, "BookName:"),
                            new User()));
                        break;
                    case 6:
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

    public static void ShowBooks(ReadOnlyCollection<Book> books)
    {

        if (books.Count == 0)
        {
            Console.WriteLine(MsgNoBooks);
            return;
        }

        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine((i + 1) + " - " + books[i].Name);
        }

    }
}