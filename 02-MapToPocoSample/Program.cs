using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MapToPocoSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<MyConfiguration>()
                .Build();

            var services = new ServiceCollection()
                .Configure<MyConfiguration>(configuration.GetSection(nameof(MyConfiguration)))
                .AddOptions()
                .BuildServiceProvider();
            
            var myConf = services.GetService<IOptions<MyConfiguration>>();
            Console.WriteLine($"The first secret is: {myConf.Value.MyFirstSecret}");
            Console.WriteLine($"The second secret is: {myConf.Value.MySecondSecret}");
        }
    }

    class MyConfiguration
    {
        public string MyFirstSecret { get; set; }
        public string MySecondSecret { get; set; }
    }
}
