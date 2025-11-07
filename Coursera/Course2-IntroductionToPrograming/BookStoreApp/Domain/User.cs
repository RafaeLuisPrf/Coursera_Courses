namespace Coursera.Course2_IntroductionToPrograming.BookStoreApp.Domain;

public class User
{
    public int BorrowedBooks  { get; set; }

    public User()
    {
        BorrowedBooks = 0;
    }
    
    public void AddBorrowedBook()
    {
        BorrowedBooks++;
    }
    
}