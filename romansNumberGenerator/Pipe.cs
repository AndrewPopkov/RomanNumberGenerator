using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace romansNumberGenerator
{
    public static class Pipe
    {
        public static void Then<TIn>(this TIn @in, Action<TIn> pipe)
            => pipe(@in);

        public static TOut Then<TIn, TOut>(this TIn @in, Func<TIn, TOut> pipe)
            => pipe(@in);

        public static async Task<TOut> ThenAsync<TIn, TOut>(this Task<TIn> inTask, Func<TIn, TOut> pipe)
        {
            var @in = await inTask.ConfigureAwait(false);
            return pipe(@in);
        }

        public static async Task ThenAsync<TIn>(this Task<TIn> inTask, Action<TIn> pipe)
        {
            var @in = await inTask.ConfigureAwait(false);
            pipe(@in);
        }

        public static async Task<TOut> ThenAsync<TOut>(this Task inTask, Func<TOut> pipe)
        {
            await inTask.ConfigureAwait(false);
            return pipe();
        }
    }
}
