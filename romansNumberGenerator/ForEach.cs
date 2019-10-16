using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> toApply)
        {
            if (source == null)
                throw new NullReferenceException(nameof(source));
            var count = 0;
            foreach (var item in source)
            {               
                toApply(item, count);
                count++;

            }
               
        }
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> toApply)
        {
            if (source == null)
                throw new NullReferenceException(nameof(source));
            foreach (var item in source)
            {
                toApply(item);
            }

        }
        public static async Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> func)
        {
            foreach (var value in source)
            {
                await func(value).ConfigureAwait(false);
            }
        }

        public static void Repeat(this int count,  Action action)
        {
            while (count-- > 0)
                action.Invoke();
        }

    }
}

