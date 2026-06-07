using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ZLinq.Linq;

namespace ZLinq
{
	public static class ValueEnumerable
	{
		public static ValueEnumerable<FromNonGenericEnumerable<object>, object> AsValueEnumerable(this IEnumerable source)
		{
			return default(ValueEnumerable<FromNonGenericEnumerable<object>, object>);
		}

		public static ValueEnumerable<FromNonGenericEnumerable<T>, T> AsValueEnumerable<T>(this IEnumerable source) where T : notnull
		{
			return default(ValueEnumerable<FromNonGenericEnumerable<T>, T>);
		}

		public static ValueEnumerable<FromEnumerable<T>, T> AsValueEnumerable<T>(this IEnumerable<T> source) where T : notnull
		{
			return default(ValueEnumerable<FromEnumerable<T>, T>);
		}

		public static ValueEnumerable<FromArray<T>, T> AsValueEnumerable<T>(this T[] source) where T : notnull
		{
			return default(ValueEnumerable<FromArray<T>, T>);
		}

		public static ValueEnumerable<FromList<T>, T> AsValueEnumerable<T>(this List<T> source) where T : notnull
		{
			return default(ValueEnumerable<FromList<T>, T>);
		}

		public static ValueEnumerable<FromMemory<T?>, T?> AsValueEnumerable<T>(this ArraySegment<T> source)
		{
			return default(ValueEnumerable<FromMemory<T>, T>);
		}

		public static ValueEnumerable<FromMemory<T?>, T?> AsValueEnumerable<T>(this Memory<T> source)
		{
			return default(ValueEnumerable<FromMemory<T>, T>);
		}

		public static ValueEnumerable<FromMemory<T?>, T?> AsValueEnumerable<T>(this ReadOnlyMemory<T> source)
		{
			return default(ValueEnumerable<FromMemory<T>, T>);
		}

		public static ValueEnumerable<FromReadOnlySequence<T?>, T?> AsValueEnumerable<T>(this ReadOnlySequence<T> source)
		{
			return default(ValueEnumerable<FromReadOnlySequence<T>, T>);
		}

		public static ValueEnumerable<FromDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source) where TKey : notnull where TValue : notnull
		{
			return default(ValueEnumerable<FromDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>);
		}

		public static ValueEnumerable<FromQueue<T>, T> AsValueEnumerable<T>(this Queue<T> source) where T : notnull
		{
			return default(ValueEnumerable<FromQueue<T>, T>);
		}

		public static ValueEnumerable<FromStack<T>, T> AsValueEnumerable<T>(this Stack<T> source) where T : notnull
		{
			return default(ValueEnumerable<FromStack<T>, T>);
		}

		public static ValueEnumerable<FromLinkedList<T>, T> AsValueEnumerable<T>(this LinkedList<T> source) where T : notnull
		{
			return default(ValueEnumerable<FromLinkedList<T>, T>);
		}

		public static ValueEnumerable<FromHashSet<T>, T> AsValueEnumerable<T>(this HashSet<T> source) where T : notnull
		{
			return default(ValueEnumerable<FromHashSet<T>, T>);
		}

		public static ValueEnumerable<FromSortedSet<T>, T> AsValueEnumerable<T>(this SortedSet<T> source) where T : notnull
		{
			return default(ValueEnumerable<FromSortedSet<T>, T>);
		}

		public static ValueEnumerable<FromEmpty<T?>, T?> Empty<T>()
		{
			return default(ValueEnumerable<FromEmpty<T>, T>);
		}

		public static ValueEnumerable<FromRange, int> Range(int start, int count)
		{
			return default(ValueEnumerable<FromRange, int>);
		}

		public static ValueEnumerable<FromRange2, int> Range(Range range, RightBound rightBound = RightBound.Exclusive)
		{
			return default(ValueEnumerable<FromRange2, int>);
		}

		public static ValueEnumerable<FromRangeDateTime, DateTime> Range(DateTime start, int count, TimeSpan step)
		{
			return default(ValueEnumerable<FromRangeDateTime, DateTime>);
		}

		public static ValueEnumerable<FromRangeDateTimeTo, DateTime> Range(DateTime start, DateTime end, TimeSpan step, RightBound rightBound)
		{
			return default(ValueEnumerable<FromRangeDateTimeTo, DateTime>);
		}

		public static ValueEnumerable<FromRangeDateTimeOffset, DateTimeOffset> Range(DateTimeOffset start, int count, TimeSpan step)
		{
			return default(ValueEnumerable<FromRangeDateTimeOffset, DateTimeOffset>);
		}

		public static ValueEnumerable<FromRangeDateTimeOffsetTo, DateTimeOffset> Range(DateTimeOffset start, DateTimeOffset end, TimeSpan step, RightBound rightBound)
		{
			return default(ValueEnumerable<FromRangeDateTimeOffsetTo, DateTimeOffset>);
		}

		public static ValueEnumerable<FromRepeat<T>, T> Repeat<T>(T element, int count) where T : notnull
		{
			return default(ValueEnumerable<FromRepeat<T>, T>);
		}
	}
	[StructLayout((LayoutKind)3)]
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	[DebuggerTypeProxy(typeof(ValueEnumerableDebugView<, >))]
	public readonly struct ValueEnumerable<TEnumerator, T> where TEnumerator : struct, IValueEnumerator<T>
	{
		public readonly TEnumerator Enumerator;

		private string DebuggerDisplay => null;

		public ValueEnumerable(TEnumerator enumerator)
		{
			Enumerator = default(TEnumerator);
		}

		public ValueEnumerable<Cast<TEnumerator?, T?, TResult?>, TResult?> Cast<TResult>()
		{
			return default(ValueEnumerable<Cast<TEnumerator, T, TResult>, TResult>);
		}

		public ValueEnumerable<OfType<TEnumerator?, T?, TResult?>, TResult?> OfType<TResult>()
		{
			return default(ValueEnumerable<OfType<TEnumerator, T, TResult>, TResult>);
		}
	}
}
