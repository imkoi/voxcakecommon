using System;
using System.Diagnostics;
using System.Threading;

namespace VoxCake.Common.CustomAwaiters
{
    public readonly struct TaskOptions
    {
        public readonly Stopwatch stopwatch;
        public readonly int maxCpuSleepMs;
        public readonly CancellationTokenSource cancellationTokenSource;
        public readonly CancellationToken cancellationToken;

        public TaskOptions(Stopwatch stopwatch, int maxCpuSleepMs,
            CancellationTokenSource cancellationTokenSource)
        {
            if (stopwatch == null || cancellationTokenSource == null)
            {
                throw new Exception("Failed to instantiate TaskOptions because is null reference fields");
            }
            
            this.stopwatch = stopwatch;
            this.maxCpuSleepMs = maxCpuSleepMs;
            this.cancellationTokenSource = cancellationTokenSource;
            cancellationToken = cancellationTokenSource.Token;
        }
        
        public static TaskOptions Default => new TaskOptions(
            Stopwatch.StartNew(),
            16,
            new CancellationTokenSource());
    }
}