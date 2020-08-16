using System;
namespace VoxCake.Common.Logger
{
    internal class ConsoleLogger : ILogger
    {
        void ILogger.Log(object message)
        {
            Console.WriteLine($"Log[ {message} ]");
        }

        void ILogger.Warning(object message)
        {
            Console.WriteLine($"Warning[ {message} ]");
        }

        void ILogger.Error(object message)
        {
            Console.WriteLine($"Error[ {message} ]");
        }
    }
}
