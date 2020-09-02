using System.Threading.Tasks;

namespace VoxCake.Common.CustomAwaiters
{
    public static class CustomAwaiter
    {
        public static async Task WaitFor(TaskOptions taskOptions)
        {
            taskOptions.cancellationToken.ThrowIfCancellationRequested();
            
            await Task.Delay(taskOptions.maxCpuSleepMs, taskOptions.cancellationToken);
        }

        public static async Task WaitMs(TaskOptions taskOptions)
        {
            taskOptions.cancellationToken.ThrowIfCancellationRequested();
            
            await Task.Delay(1, taskOptions.cancellationToken);
        }

        public static async Task ReduceCpuSleep(TaskOptions taskOptions)
        {
            taskOptions.cancellationToken.ThrowIfCancellationRequested();

            if (taskOptions.stopwatch.ElapsedMilliseconds > taskOptions.maxCpuSleepMs)
            {
                taskOptions.stopwatch.Restart();
                await WaitMs(taskOptions);
            }
        }
    }
}