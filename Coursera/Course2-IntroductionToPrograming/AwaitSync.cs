using System;

namespace Coursera.Course2_IntroductionToPrograming;

public class AwaitSync
{

    public async Task<string> run()
    {
        await Task.Delay(5000);

        return "After 5 seconds, Here we are";
    }
    
}