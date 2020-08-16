namespace VoxCake.Common.Logger
{
    public interface ILogger
    {
        void Log(object message);
        void Warning(object message);
        void Error(object message);
    }
}
