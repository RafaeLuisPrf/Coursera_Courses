using Coursera.Course1;
using Coursera.Course2_IntroductionToPrograming;
using Coursera.Course2_IntroductionToPrograming.BookStoreApp.Domain;
using Coursera.Course2_IntroductionToPrograming.BookStoreApp.Presentation;

public class Program
{

    public static User UserStatic = new User();
    public static void Main(string[] args)
    {
        //BookStoreConsoleUI.MainLoop();
        int beggining = 310;
        int sum = 0;
        for (int i = 21; i < 110; i++)
        {
            sum += beggining;
            beggining += 10;
        }
        Console.WriteLine(sum);
    }

    public static async Task runProgram()
    {
        try
        {
            //ProductOperation.run();        
            AwaitSync awaitSync = new AwaitSync();
            
            Console.WriteLine("Before Run");
            string result = await awaitSync.run();
            Console.WriteLine("After Run:"+result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("AwaitSync Error:"+ex.Message);
        }
        
        
    }

}


