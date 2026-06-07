using System;
using System.Runtime.CompilerServices;
using CommunityToolkit.HighPerformance.Helpers;

namespace CommunityToolkit.HighPerformance
{
	public static class HashCodeExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Add<T>(this ref HashCode hashCode, ReadOnlySpan<T> span) where T : notnull
		{
			int value = HashCode<T>.CombineValues(span);
			hashCode.Add(value);
		}
	}
}
