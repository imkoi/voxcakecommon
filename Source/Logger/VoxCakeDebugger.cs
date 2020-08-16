using System;

namespace VoxCake.Common.Logger
{
    public static class VoxCakeDebugger
    {
        public static ILogger Logger { private get; set; }

        public static void Log(string log)
        {
            ValidateLogger();
            Logger?.Log(log);
        }
        
        public static void Log(object sender, string log)
        {
            var message = sender == null ? log : $"{sender.GetType().Name} : {log}";
            
            ValidateLogger();
            Logger?.Log(message);
        }

        public static void Warning(string log)
        {
            ValidateLogger();
            Logger?.Warning(log);
        }
        
        public static void Warning(object sender,string log)
        {
            var message = sender == null ? log : $"{sender.GetType().Name} : {log}";
            
            ValidateLogger();
            Logger?.Warning(message);
        }

        public static void Error(string log)
        {
            ValidateLogger();
            Logger?.Error(log);
        }
        
        public static void Error(object sender, string log)
        {
            var message = sender == null ? log : $"{sender.GetType().Name} : {log}";
            
            ValidateLogger();
            Logger?.Error(message);
        }

        private static void ValidateLogger()
        {
            if (Logger == null)
            {
                throw new Exception("Logger not setted up!");
            }
        }
    }
}