using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace Cysharp.Threading.Tasks.Internal
{
	internal static class StatePool<T1>
	{
		private static readonly ConcurrentQueue<StateTuple<T1>> queue;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static StateTuple<T1> Create(T1 item1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Return(StateTuple<T1> tuple)
		{
		}
	}
}
