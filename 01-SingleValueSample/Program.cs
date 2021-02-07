using System;
using Microsoft.Extensions.Configuration;

namespace SingleValueSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            var secretValue = configuration["MySecret"];

            Console.WriteLine($"The secret value is: {secretValue}");
        }
    }
}
