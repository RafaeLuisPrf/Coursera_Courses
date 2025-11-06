namespace Coursera.Shared;

public static class Reader
{
    public static string ReadLineImp(string errorMessage,string question)
    {
        try
        {
            string? res = null;
            Console.Write(question);
            while (string.IsNullOrEmpty(res = Console.ReadLine()))
            {
                Console.WriteLine("Error:" + errorMessage);
                Console.Write("R:");
            }

            return res;
        }
        catch (Exception ex)
        {
            Console.WriteLine("EXCEPTION IN READING:" + ex.Message);
            return ReadLineImp(errorMessage,question);
        }
    }
}
