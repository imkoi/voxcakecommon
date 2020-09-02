using System.Collections.Generic;
using System.Threading.Tasks;
using VoxCake.Common.CustomAwaiters;

namespace VoxCake.Common.AsyncCollections
{
    public partial class AsyncCollections
    {
        public static async Task<Dictionary<TKey, TValue>> GetMergedDictionary<TKey, TValue>(Dictionary<TKey, TValue> collectionA,
            Dictionary<TKey, TValue> collectionB, TaskOptions taskOptions)
        {
            taskOptions.cancellationToken.ThrowIfCancellationRequested();
            
            var result = new Dictionary<TKey, TValue>();
            
            foreach (var pair in collectionA)
            {
                await AddPairToCollection(pair, result, taskOptions);
            }

            foreach (var pair in collectionB)
            {
                await AddPairToCollection(pair, result, taskOptions);
            }

            return result;
        }
        
        public static async Task AddPairToCollection<TKey, TValue>(KeyValuePair<TKey, TValue> pair,
            Dictionary<TKey, TValue> collection, TaskOptions taskOptions)
        {
            taskOptions.cancellationToken.ThrowIfCancellationRequested();

            if (!collection.ContainsKey(pair.Key))
            {
                collection.Add(pair.Key, pair.Value);
            }
            
            await CustomAwaiter.ReduceCpuSleep(taskOptions);
        }
    }
}