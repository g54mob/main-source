using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct TakeLast<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private readonly int takeCount;

		private int state;

		private RentedRingBuffer<TSource>? ringBuffer;

		public TakeLast(TEnumerator source, int count)
		{
			ringBuffer = null;
			this.source = source;
			takeCount = Math.Max(0, count);
			state = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (source.TryGetNonEnumeratedCount(out count))
			{
				count = Math.Min(count, takeCount);
				return true;
			}
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			if (source.TryGetSpan(out span))
			{
				if (span.Length > takeCount)
				{
					int num = takeCount;
					int length = span.Length;
					int num2 = length - num;
					span = span.Slice(num2, length - num2);
				}
				return true;
			}
			span = default(ReadOnlySpan<TSource>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TSource> destination, Index offset)
		{
			if (source.TryGetNonEnumeratedCount(out var count))
			{
				int num = Math.Min(count, takeCount);
				if (num <= 0)
				{
					return false;
				}
				int num2 = count - num;
				int offset2 = offset.GetOffset(num);
				if (offset2 < 0 || offset2 >= num)
				{
					return false;
				}
				int num3 = num2 + offset2;
				int num4 = Math.Min(num - offset2, destination.Length);
				if (num4 <= 0)
				{
					return false;
				}
				return source.TryCopyTo(destination.Slice(0, num4), num3);
			}
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			switch (state)
			{
			case 0:
				return TryGetNextFirstPath(out current);
			case 1:
				return source.TryGetNext(out current);
			case 2:
				return ringBuffer.TryDequeue(out current);
			default:
				Unsafe.SkipInit<TSource>(out current);
				return false;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool TryGetNextFirstPath(out TSource current)
		{
			Unsafe.SkipInit<TSource>(out current);
			if (takeCount == 0)
			{
				state = 3;
				return false;
			}
			if (source.TryGetNonEnumeratedCount(out var count))
			{
				int num = Math.Max(0, count - takeCount);
				while (source.TryGetNext(out current))
				{
					if (--num < 0)
					{
						state = 1;
						return true;
					}
				}
				state = 3;
				return false;
			}
			RentedRingBuffer<TSource> rentedRingBuffer = (ringBuffer = new RentedRingBuffer<TSource>(takeCount));
			TSource current2;
			while (source.TryGetNext(out current2))
			{
				rentedRingBuffer.Enqueue(current2);
			}
			state = 2;
			if (rentedRingBuffer.TryDequeue(out current))
			{
				return true;
			}
			state = 3;
			return false;
		}

		public void Dispose()
		{
			ringBuffer?.Dispose();
			source.Dispose();
		}
	}
}
