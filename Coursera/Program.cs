

using Coursera.Course1;
using Coursera.Course2_IntroductionToPrograming;

public class Program
{


    public static void Main(string[] args)
    {
        BookStoreConsoleUI.MainLoop();
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


