using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace UseHostBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<MyConfiguration>(hostContext.Configuration.GetSection(nameof(MyConfiguration)));
                    services.AddHostedService<ConsoleWorker>();
                }).Build().Run();
        }
    }

    class MyConfiguration
    {
        public string MyFirstSecret { get; set; }
        public string MySecondSecret { get; set; }
    }

    class ConsoleWorker : BackgroundService
    {
        private readonly MyConfiguration _myConfiguration;
        private readonly ILogger _logger;

        public ConsoleWorker(IOptions<MyConfiguration> myConfiguration, ILogger<ConsoleWorker> logger)
        {
            _myConfiguration = myConfiguration.Value;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"The first secret is: {_myConfiguration.MyFirstSecret}");
            _logger.LogInformation($"The second secret is: {_myConfiguration.MySecondSecret}");

            return Task.CompletedTask;
        }
    }
}
