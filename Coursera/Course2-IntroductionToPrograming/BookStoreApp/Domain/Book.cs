namespace Coursera.Course2_IntroductionToPrograming.BookStoreApp.Domain;

public class Book
{
    
    public string Name { get; set; }
    private bool Borrowed { get; set; }
    public Book(string name)
    {
        Name = name;
        Borrowed = false;
    }


    public void BorrowBook()
    {
        Borrowed = true;
    }
    
}