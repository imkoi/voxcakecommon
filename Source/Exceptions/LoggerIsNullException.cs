using System;

namespace VoxCake.Common.Internal
{
    [Serializable]
    internal class LoggerIsNullException : Exception
    {
        internal LoggerIsNullException() : base("")
        {

        }
    }
}