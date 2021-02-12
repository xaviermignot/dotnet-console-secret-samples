using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .Build();

var secretValue = configuration["MySecret"];

Console.WriteLine($"The secret value is: {secretValue}");