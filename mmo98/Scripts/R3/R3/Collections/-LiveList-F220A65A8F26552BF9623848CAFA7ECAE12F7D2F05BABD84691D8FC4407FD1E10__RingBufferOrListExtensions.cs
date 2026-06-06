using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using R3.Internal;

namespace R3.Collections
{
	internal static class _003CLiveList_003EF220A65A8F26552BF9623848CAFA7ECAE12F7D2F05BABD84691D8FC4407FD1E10__RingBufferOrListExtensions
	{
		public static RingBufferSpan<T> GetSpan<T>(this IReadOnlyList<T> list)
		{
			if (list is RingBuffer<T> ringBuffer)
			{
				return ringBuffer.GetSpan();
			}
			if (list is List<T> list2)
			{
				Span<T> span = CollectionsMarshal.AsSpan(list2);
				return new RingBufferSpan<T>(span, default(ReadOnlySpan<T>), span.Length);
			}
			throw new NotSupportedException();
		}

		public static void Clear<T>(this IReadOnlyList<T> list)
		{
			if (list is RingBuffer<T> ringBuffer)
			{
				ringBuffer.Clear();
				return;
			}
			if (list is List<T> list2)
			{
				list2.Clear();
				return;
			}
			throw new NotSupportedException();
		}

		public static T[] ToArray<T>(this IReadOnlyList<T> list)
		{
			if (list is RingBuffer<T> ringBuffer)
			{
				return ringBuffer.ToArray();
			}
			if (list is List<T> list2)
			{
				return CollectionsMarshal.AsSpan(list2).ToArray();
			}
			throw new NotSupportedException();
		}
	}
}
