using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.File.Header;
using SerilogLoggingApp;
using System.Reflection;
using Serilog.Core;
using Serilog.Core.Enrichers;
using Serilog.Context;

public class Program
{
    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        //Log.Logger = new LoggerConfiguration()
        //    .WriteTo.File("logs/logs.txt", hooks: new HeaderWriter("======================================================================================================================================================{NewLine}Logging start    = {Timestamp:yyyy-MM-dd HH:mm:ss.ffff}{NewLine}Machine name     = {MachineName}{NewLine}Version          = 0.0.0.0{NewLine}AssemblyVersion  = 1.0.0.0{NewLine}Windows Version  = Windows 10 Enterprise{NewLine}----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------{NewLine}Date and Time            | Level | Product              | Module                                                     | Message{NewLine}----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------{NewLine}"))
        //    .CreateLogger();
        
        Log.Logger =new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        //Log.Information("======================================================================================================================================================{NewLine}Logging start    = {Timestamp:yyyy-MM-dd HH:mm:ss.ffff}{NewLine}Machine name     = {MachineName}{NewLine}Version          = 0.0.0.0{NewLine}AssemblyVersion  = 1.0.0.0{NewLine}Windows Version  = Windows 10 Enterprise{NewLine}----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------{NewLine}Date and Time            | Level | Product              | Module                                                     | Message{NewLine}----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------{NewLine}");

        //LogContext.PushProperty("Header", "======================================================================================================================================================{NewLine}Logging start    = {Timestamp:yyyy-MM-dd HH:mm:ss.ffff}{NewLine}Machine name     = {MachineName}{NewLine}Version          = 0.0.0.0{NewLine}AssemblyVersion  = 1.0.0.0{NewLine}Windows Version  = Windows 10 Enterprise{NewLine}----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------{NewLine}Date and Time            | Level | Product              | Module                                                     | Message{NewLine}----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------{NewLine}");
        //Log.Logger = new LoggerConfiguration()
        //    .MinimumLevel.Debug()
        //    .WriteTo.Console()
        //    .WriteTo.File("logs/logs.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.ffff} | {Level:u5} | {Properties:j} | {SourceContext} | {Message:lj}{NewLine}{Exception}")
        //    .CreateLogger();

        try
        {
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application startup failed");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 })
                 .UseSerilog((hostingContext, loggerConfiguration) =>
                 {
                     loggerConfiguration
                         .ReadFrom.Configuration(hostingContext.Configuration)
                         .Enrich.WithProperty("MachineName", Environment.MachineName)
                         .Enrich.WithProperty("Version", Assembly.GetExecutingAssembly().GetName().Version);
                 });
}