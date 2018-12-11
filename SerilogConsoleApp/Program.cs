using System;
using Serilog;

namespace SerilogConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("C:\\will\\logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Hello World!");

            int a = 10, b = 0;
            try
            {
                Log.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            } catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong!");
            }

            Log.CloseAndFlush();
            Console.ReadKey();
        }
    }
}
