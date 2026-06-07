using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ZLinq.Internal;
using ZLinq.Linq;

namespace ZLinq
{
	public static class ValueEnumerable
	{
		public static ValueEnumerable<FromNonGenericEnumerable<object>, object> AsValueEnumerable(this IEnumerable source)
		{
			return new ValueEnumerable<FromNonGenericEnumerable<object>, object>(new FromNonGenericEnumerable<object>(Throws.IfNull(source, "source")));
		}

		public static ValueEnumerable<FromNonGenericEnumerable<T>, T> AsValueEnumerable<T>(this IEnumerable source)
		{
			return new ValueEnumerable<FromNonGenericEnumerable<T>, T>(new FromNonGenericEnumerable<T>(Throws.IfNull(source, "source")));
		}

		public static ValueEnumerable<FromEnumerable<T>, T> AsValueEnumerable<T>(this IEnumerable<T> source)
		{
			return new ValueEnumerable<FromEnumerable<T>, T>(new FromEnumerable<T>(Throws.IfNull(source, "source")));
		}

		public static ValueEnumerable<FromArray<T>, T> AsValueEnumerable<T>(this T[] source)
		{
			return new ValueEnumerable<FromArray<T>, T>(new FromArray<T>(Throws.IfNull(source, "source")));
		}

		public static ValueEnumerable<FromList<T>, T> AsValueEnumerable<T>(this List<T> source)
		{
			return new ValueEnumerable<FromList<T>, T>(new FromList<T>(Throws.IfNull(source, "source")));
		}

		public static ValueEnumerable<FromMemory<T>, T> AsValueEnumerable<T>(this ArraySegment<T> source)
		{
			return new ValueEnumerable<FromMemory<T>, T>(new FromMemory<T>(source));
		}

		public static ValueEnumerable<FromMemory<T>, T> AsValueEnumerable<T>(this Memory<T> source)
		{
			return new ValueEnumerable<FromMemory<T>, T>(new FromMemory<T>(source));
		}

		public static ValueEnumerable<FromMemory<T>, T> AsValueEnumerable<T>(this ReadOnlyMemory<T> source)
		{
			return new ValueEnumerable<FromMemory<T>, T>(new FromMemory<T>(source));
		}

		public static ValueEnumerable<FromReadOnlySequence<T>, T> AsValueEnumerable<T>(this ReadOnlySequence<T> source)
		{
			return new ValueEnumerable<FromReadOnlySequence<T>, T>(new FromReadOnlySequence<T>(source));
		}

		public static ValueEnumerable<FromDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source) where TKey : notnull
		{
			return new ValueEnumerable<FromDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>(new FromDictionary<TKey, TValue>(Throws.IfNull(source, "source")));
		}

		public static ValueEnumerable<FromSortedDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source) where TKey : notnull
		{
			return new ValueEnumerable<FromSortedDictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>(new FromSortedDictionary<TKey, TValue>(Throws.IfNull(source, "source")));
		}

		public static ValueEnumerable<FromQueue<T>, T> AsValueEnumerable<T>(this Queue<T> source)
		{
			return new ValueEnumerable<FromQueue<T>, T>(new FromQueue<T>(Throws.IfNull(source, "source")));
		}

		public static ValueEnumerable<FromStack<T>, T> AsValueEnumerable<T>(this Stack<T> source)
		{
			return new ValueEnumerable<FromStack<T>, T>(new FromStack<T>(Throws.IfNull(source, "source")));
		}

		public static ValueEnumerable<FromLinkedList<T>, T> AsValueEnumerable<T>(this LinkedList<T> source)
		{
			return new ValueEnumerable<FromLinkedList<T>, T>(new FromLinkedList<T>(Throws.IfNull(source, "source")));
		}

		public static ValueEnumerable<FromHashSet<T>, T> AsValueEnumerable<T>(this HashSet<T> source)
		{
			return new ValueEnumerable<FromHashSet<T>, T>(new FromHashSet<T>(Throws.IfNull(source, "source")));
		}

		public static ValueEnumerable<FromSortedSet<T>, T> AsValueEnumerable<T>(this SortedSet<T> source)
		{
			return new ValueEnumerable<FromSortedSet<T>, T>(new FromSortedSet<T>(Throws.IfNull(source, "source")));
		}

		public static ValueEnumerable<FromEmpty<T>, T> Empty<T>()
		{
			return new ValueEnumerable<FromEmpty<T>, T>(default(FromEmpty<T>));
		}

		public static ValueEnumerable<FromByteInfiniteSequence, byte> InfiniteSequence(byte start, byte step)
		{
			return new ValueEnumerable<FromByteInfiniteSequence, byte>(new FromByteInfiniteSequence(start, step));
		}

		public static ValueEnumerable<FromSByteInfiniteSequence, sbyte> InfiniteSequence(sbyte start, sbyte step)
		{
			return new ValueEnumerable<FromSByteInfiniteSequence, sbyte>(new FromSByteInfiniteSequence(start, step));
		}

		public static ValueEnumerable<FromUInt16InfiniteSequence, ushort> InfiniteSequence(ushort start, ushort step)
		{
			return new ValueEnumerable<FromUInt16InfiniteSequence, ushort>(new FromUInt16InfiniteSequence(start, step));
		}

		public static ValueEnumerable<FromInt16InfiniteSequence, short> InfiniteSequence(short start, short step)
		{
			return new ValueEnumerable<FromInt16InfiniteSequence, short>(new FromInt16InfiniteSequence(start, step));
		}

		public static ValueEnumerable<FromUInt32InfiniteSequence, uint> InfiniteSequence(uint start, uint step)
		{
			return new ValueEnumerable<FromUInt32InfiniteSequence, uint>(new FromUInt32InfiniteSequence(start, step));
		}

		public static ValueEnumerable<FromInt32InfiniteSequence, int> InfiniteSequence(int start, int step)
		{
			return new ValueEnumerable<FromInt32InfiniteSequence, int>(new FromInt32InfiniteSequence(start, step));
		}

		public static ValueEnumerable<FromUInt64InfiniteSequence, ulong> InfiniteSequence(ulong start, ulong step)
		{
			return new ValueEnumerable<FromUInt64InfiniteSequence, ulong>(new FromUInt64InfiniteSequence(start, step));
		}

		public static ValueEnumerable<FromInt64InfiniteSequence, long> InfiniteSequence(long start, long step)
		{
			return new ValueEnumerable<FromInt64InfiniteSequence, long>(new FromInt64InfiniteSequence(start, step));
		}

		public static ValueEnumerable<FromCharInfiniteSequence, char> InfiniteSequence(char start, char step)
		{
			return new ValueEnumerable<FromCharInfiniteSequence, char>(new FromCharInfiniteSequence(start, step));
		}

		public static ValueEnumerable<FromSingleInfiniteSequence, float> InfiniteSequence(float start, float step)
		{
			return new ValueEnumerable<FromSingleInfiniteSequence, float>(new FromSingleInfiniteSequence(start, step));
		}

		public static ValueEnumerable<FromDoubleInfiniteSequence, double> InfiniteSequence(double start, double step)
		{
			return new ValueEnumerable<FromDoubleInfiniteSequence, double>(new FromDoubleInfiniteSequence(start, step));
		}

		public static ValueEnumerable<FromDecimalInfiniteSequence, decimal> InfiniteSequence(decimal start, decimal step)
		{
			return new ValueEnumerable<FromDecimalInfiniteSequence, decimal>(new FromDecimalInfiniteSequence(start, step));
		}

		public static ValueEnumerable<FromInfiniteSequenceDateTime, DateTime> InfiniteSequence(DateTime start, TimeSpan step)
		{
			return new ValueEnumerable<FromInfiniteSequenceDateTime, DateTime>(new FromInfiniteSequenceDateTime(start, step));
		}

		public static ValueEnumerable<FromInfiniteSequenceDateTimeOffset, DateTimeOffset> InfiniteSequence(DateTimeOffset start, TimeSpan step)
		{
			return new ValueEnumerable<FromInfiniteSequenceDateTimeOffset, DateTimeOffset>(new FromInfiniteSequenceDateTimeOffset(start, step));
		}

		public static ValueEnumerable<FromRange, int> Range(int start, int count)
		{
			long num = (long)start + (long)count - 1;
			if (count < 0 || num > int.MaxValue)
			{
				Throws.ArgumentOutOfRange("count");
			}
			return new ValueEnumerable<FromRange, int>(new FromRange(start, count));
		}

		public static ValueEnumerable<FromRangeDateTime, DateTime> Range(DateTime start, int count, TimeSpan step)
		{
			return new ValueEnumerable<FromRangeDateTime, DateTime>(new FromRangeDateTime(start, count, step));
		}

		public static ValueEnumerable<FromRangeDateTimeOffset, DateTimeOffset> Range(DateTimeOffset start, int count, TimeSpan step)
		{
			return new ValueEnumerable<FromRangeDateTimeOffset, DateTimeOffset>(new FromRangeDateTimeOffset(start, count, step));
		}

		[Obsolete("Use ValueEnumerable.Sequence instead. This will be removed in a future version.")]
		public static ValueEnumerable<FromRange2, int> Range(Range range, RightBound rightBound = RightBound.Exclusive)
		{
			if (range.Start.IsFromEnd)
			{
				Throws.IsFromEnd("range");
			}
			if (range.End.IsFromEnd)
			{
				if (range.End.Value == 0)
				{
					return new ValueEnumerable<FromRange2, int>(new FromRange2(range.Start.Value, 0, isInfinite: true));
				}
				Throws.IsFromEnd("range");
			}
			int value = range.Start.Value;
			int num = range.End.Value - range.Start.Value;
			if (rightBound == RightBound.Inclusive)
			{
				num++;
			}
			long num2 = (long)value + (long)num - 1;
			if (num < 0 || num2 > int.MaxValue)
			{
				Throws.ArgumentOutOfRange("range");
			}
			return new ValueEnumerable<FromRange2, int>(new FromRange2(value, num, isInfinite: false));
		}

		[Obsolete("Use ValueEnumerable.Sequence instead. This will be removed in a future version.")]
		public static ValueEnumerable<FromRangeDateTimeTo, DateTime> Range(DateTime start, DateTime end, TimeSpan step, RightBound rightBound)
		{
			return new ValueEnumerable<FromRangeDateTimeTo, DateTime>(new FromRangeDateTimeTo(start, end, step, rightBound));
		}

		[Obsolete("Use ValueEnumerable.Sequence instead. This will be removed in a future version.")]
		public static ValueEnumerable<FromRangeDateTimeOffsetTo, DateTimeOffset> Range(DateTimeOffset start, DateTimeOffset end, TimeSpan step, RightBound rightBound)
		{
			return new ValueEnumerable<FromRangeDateTimeOffsetTo, DateTimeOffset>(new FromRangeDateTimeOffsetTo(start, end, step, rightBound));
		}

		public static ValueEnumerable<FromRepeat<T>, T> Repeat<T>(T element, int count)
		{
			if (count < 0)
			{
				Throws.ArgumentOutOfRange("count");
			}
			return new ValueEnumerable<FromRepeat<T>, T>(new FromRepeat<T>(element, count));
		}

		public static ValueEnumerable<FromSequenceDateTime, DateTime> Sequence(DateTime start, DateTime endInclusive, TimeSpan step)
		{
			if (step == TimeSpan.Zero)
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromSequenceDateTime, DateTime>(new FromSequenceDateTime(start, endInclusive, step, isIncrement: true));
			}
			if (step >= TimeSpan.Zero)
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromSequenceDateTime, DateTime>(new FromSequenceDateTime(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromSequenceDateTime, DateTime>(new FromSequenceDateTime(start, endInclusive, step, isIncrement: false));
		}

		public static ValueEnumerable<FromSequenceDateTimeOffset, DateTimeOffset> Sequence(DateTimeOffset start, DateTimeOffset endInclusive, TimeSpan step)
		{
			if (step == TimeSpan.Zero)
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromSequenceDateTimeOffset, DateTimeOffset>(new FromSequenceDateTimeOffset(start, endInclusive, step, isIncrement: true));
			}
			if (step >= TimeSpan.Zero)
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromSequenceDateTimeOffset, DateTimeOffset>(new FromSequenceDateTimeOffset(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromSequenceDateTimeOffset, DateTimeOffset>(new FromSequenceDateTimeOffset(start, endInclusive, step, isIncrement: false));
		}

		public static ValueEnumerable<FromByteSequence, byte> Sequence(byte start, byte endInclusive, byte step)
		{
			if (step == 0)
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromByteSequence, byte>(new FromByteSequence(start, endInclusive, step, isIncrement: true));
			}
			if (step >= 0)
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromByteSequence, byte>(new FromByteSequence(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromByteSequence, byte>(new FromByteSequence(start, endInclusive, step, isIncrement: false));
		}

		public static ValueEnumerable<FromSByteSequence, sbyte> Sequence(sbyte start, sbyte endInclusive, sbyte step)
		{
			if (step == 0)
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromSByteSequence, sbyte>(new FromSByteSequence(start, endInclusive, step, isIncrement: true));
			}
			if (step >= 0)
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromSByteSequence, sbyte>(new FromSByteSequence(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromSByteSequence, sbyte>(new FromSByteSequence(start, endInclusive, step, isIncrement: false));
		}

		public static ValueEnumerable<FromUInt16Sequence, ushort> Sequence(ushort start, ushort endInclusive, ushort step)
		{
			if (step == 0)
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromUInt16Sequence, ushort>(new FromUInt16Sequence(start, endInclusive, step, isIncrement: true));
			}
			if (step >= 0)
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromUInt16Sequence, ushort>(new FromUInt16Sequence(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromUInt16Sequence, ushort>(new FromUInt16Sequence(start, endInclusive, step, isIncrement: false));
		}

		public static ValueEnumerable<FromInt16Sequence, short> Sequence(short start, short endInclusive, short step)
		{
			if (step == 0)
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromInt16Sequence, short>(new FromInt16Sequence(start, endInclusive, step, isIncrement: true));
			}
			if (step >= 0)
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromInt16Sequence, short>(new FromInt16Sequence(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromInt16Sequence, short>(new FromInt16Sequence(start, endInclusive, step, isIncrement: false));
		}

		public static ValueEnumerable<FromUInt32Sequence, uint> Sequence(uint start, uint endInclusive, uint step)
		{
			if (step == 0)
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromUInt32Sequence, uint>(new FromUInt32Sequence(start, endInclusive, step, isIncrement: true));
			}
			if (step >= 0)
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromUInt32Sequence, uint>(new FromUInt32Sequence(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromUInt32Sequence, uint>(new FromUInt32Sequence(start, endInclusive, step, isIncrement: false));
		}

		public static ValueEnumerable<FromInt32Sequence, int> Sequence(int start, int endInclusive, int step)
		{
			if (step == 0)
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromInt32Sequence, int>(new FromInt32Sequence(start, endInclusive, step, isIncrement: true));
			}
			if (step >= 0)
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromInt32Sequence, int>(new FromInt32Sequence(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromInt32Sequence, int>(new FromInt32Sequence(start, endInclusive, step, isIncrement: false));
		}

		public static ValueEnumerable<FromUInt64Sequence, ulong> Sequence(ulong start, ulong endInclusive, ulong step)
		{
			if (step == 0L)
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromUInt64Sequence, ulong>(new FromUInt64Sequence(start, endInclusive, step, isIncrement: true));
			}
			if (step >= 0)
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromUInt64Sequence, ulong>(new FromUInt64Sequence(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromUInt64Sequence, ulong>(new FromUInt64Sequence(start, endInclusive, step, isIncrement: false));
		}

		public static ValueEnumerable<FromInt64Sequence, long> Sequence(long start, long endInclusive, long step)
		{
			if (step == 0L)
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromInt64Sequence, long>(new FromInt64Sequence(start, endInclusive, step, isIncrement: true));
			}
			if (step >= 0)
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromInt64Sequence, long>(new FromInt64Sequence(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromInt64Sequence, long>(new FromInt64Sequence(start, endInclusive, step, isIncrement: false));
		}

		public static ValueEnumerable<FromCharSequence, char> Sequence(char start, char endInclusive, char step)
		{
			if (step == '\0')
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromCharSequence, char>(new FromCharSequence(start, endInclusive, step, isIncrement: true));
			}
			if (step >= '\0')
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromCharSequence, char>(new FromCharSequence(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromCharSequence, char>(new FromCharSequence(start, endInclusive, step, isIncrement: false));
		}

		public static ValueEnumerable<FromSingleSequence, float> Sequence(float start, float endInclusive, float step)
		{
			if (float.IsNaN(start))
			{
				Throws.ArgumentOutOfRange("start");
			}
			if (float.IsNaN(endInclusive))
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			if (float.IsNaN(step))
			{
				Throws.ArgumentOutOfRange("step");
			}
			if (step == 0f)
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromSingleSequence, float>(new FromSingleSequence(start, endInclusive, step, isIncrement: true));
			}
			if (step >= 0f)
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromSingleSequence, float>(new FromSingleSequence(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromSingleSequence, float>(new FromSingleSequence(start, endInclusive, step, isIncrement: false));
		}

		public static ValueEnumerable<FromDoubleSequence, double> Sequence(double start, double endInclusive, double step)
		{
			if (double.IsNaN(start))
			{
				Throws.ArgumentOutOfRange("start");
			}
			if (double.IsNaN(endInclusive))
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			if (double.IsNaN(step))
			{
				Throws.ArgumentOutOfRange("step");
			}
			if (step == 0.0)
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromDoubleSequence, double>(new FromDoubleSequence(start, endInclusive, step, isIncrement: true));
			}
			if (step >= 0.0)
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromDoubleSequence, double>(new FromDoubleSequence(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromDoubleSequence, double>(new FromDoubleSequence(start, endInclusive, step, isIncrement: false));
		}

		public static ValueEnumerable<FromDecimalSequence, decimal> Sequence(decimal start, decimal endInclusive, decimal step)
		{
			if (step == 0m)
			{
				if (start != endInclusive)
				{
					Throws.ArgumentOutOfRange("step");
				}
				return new ValueEnumerable<FromDecimalSequence, decimal>(new FromDecimalSequence(start, endInclusive, step, isIncrement: true));
			}
			if (step >= 0m)
			{
				if (endInclusive < start)
				{
					Throws.ArgumentOutOfRange("endInclusive");
				}
				return new ValueEnumerable<FromDecimalSequence, decimal>(new FromDecimalSequence(start, endInclusive, step, isIncrement: true));
			}
			if (endInclusive > start)
			{
				Throws.ArgumentOutOfRange("endInclusive");
			}
			return new ValueEnumerable<FromDecimalSequence, decimal>(new FromDecimalSequence(start, endInclusive, step, isIncrement: false));
		}
	}
	[StructLayout(LayoutKind.Auto)]
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	[DebuggerTypeProxy(typeof(ValueEnumerableDebugView<, >))]
	public readonly struct ValueEnumerable<TEnumerator, T> where TEnumerator : struct, IValueEnumerator<T>
	{
		public readonly TEnumerator Enumerator;

		private string DebuggerDisplay => ValueEnumerableDebuggerDisplayHelper.BuildDisplayText(typeof(TEnumerator));

		public ValueEnumerable(TEnumerator enumerator)
		{
			Enumerator = enumerator;
		}

		public ValueEnumerable<Cast<TEnumerator, T, TResult>, TResult> Cast<TResult>()
		{
			return new ValueEnumerable<Cast<TEnumerator, T, TResult>, TResult>(new Cast<TEnumerator, T, TResult>(Enumerator));
		}

		public ValueEnumerable<OfType<TEnumerator, T, TResult>, TResult> OfType<TResult>()
		{
			return new ValueEnumerable<OfType<TEnumerator, T, TResult>, TResult>(new OfType<TEnumerator, T, TResult>(Enumerator));
		}
	}
}
