using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace VoxCake.Common.Utilities
{
    public static class Awaiter
    {
        public static async Task WaitFor(int milliseconds, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(milliseconds, cancellationToken);
            }
            catch
            {
                // ignored
            }
        }

        public static async Task WaitMs(CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(1, cancellationToken);
            }
            catch
            {
                // ignored
            }
        }
        
        public static async Task ReduceTaskFreezeAsync(Stopwatch sw, int maxTaskFreezeMs,
            CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (sw.ElapsedMilliseconds > maxTaskFreezeMs)
                {
                    sw.Restart();
                    await WaitMs(cancellationToken);
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}