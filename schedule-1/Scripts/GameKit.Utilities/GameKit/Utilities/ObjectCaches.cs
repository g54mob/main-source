using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GameKit.Utilities
{
	public static class ObjectCaches<T>
	{
		private static readonly Stack<T> _stack;

		public static T Retrieve()
		{
			return default(T);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void StoreAndDefault(ref T value)
		{
		}

		public static void Store(T value)
		{
		}
	}
}
