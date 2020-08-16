using System;
using System.Runtime.Serialization;

namespace VoxCake.Common.Utilities
{
    public static class InstanceAllocator
    {
        public static T Allocate<T>()
        {
            return (T)FormatterServices.GetUninitializedObject(typeof(T));
        }

        public static object Allocate(Type type)
        {
            return FormatterServices.GetUninitializedObject(type);
        }
    }
}