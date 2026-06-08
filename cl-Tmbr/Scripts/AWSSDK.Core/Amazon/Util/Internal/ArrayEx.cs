using System;
using System.Runtime.CompilerServices;

namespace Amazon.Util.Internal
{
	internal static class ArrayEx
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[] Empty<T>()
		{
			return Array.Empty<T>();
		}
	}
}
