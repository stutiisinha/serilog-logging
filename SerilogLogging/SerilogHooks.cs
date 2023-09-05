using Serilog.Sinks.File.Header;

namespace SerilogLogging
{
    public class SerilogHooks
    {
        public static HeaderWriter MyHeaderWriter => new HeaderWriter("======================================================================================================================================================\nLogging start    = {Timestamp:yyyy-MM-dd HH:mm:ss.ffff}\nMachine name     = {MachineName}\nVersion          = 0.0.0.0\nAssemblyVersion  = 1.0.0.0\nWindows Version  = Windows 10 Enterprise\n----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\nDate and Time            | Level | Product              | Module                                                     | Message\n----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
    }
}
