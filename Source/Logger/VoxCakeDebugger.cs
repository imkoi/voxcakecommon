using VoxCake.Common.Internal;

namespace VoxCake.Common
{
    public static class VoxCakeDebugger
    {
        public static ILogger Logger { private get; set; }

        public static void LogInfo(string log)
        {
            if(Logger != null)
            {
                Logger.Log(log);
            }
            else
            {
                Logger = new DefaultLogger();
            }
        }

        public static void LogWarning(string log)
        {
            if (Logger != null)
            {
                Logger.Warning(log);
            }
            else
            {
                Logger = new DefaultLogger();
            }
        }

        public static void LogError(string log)
        {
            if (Logger != null)
            {
                Logger.Error(log);
            }
            else
            {
                Logger = new DefaultLogger();
            }
        }
    }
}