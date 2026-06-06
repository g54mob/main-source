using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct SkipLast<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private readonly int skipCount;

		private RefBox<ValueQueue<TSource>>? buffer;

		public SkipLast(TEnumerator source, int count)
		{
			buffer = null;
			this.source = source;
			skipCount = Math.Max(0, count);
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (source.TryGetNonEnumeratedCount(out count))
			{
				count = Math.Max(0, count - skipCount);
				return true;
			}
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			if (source.TryGetSpan(out span))
			{
				if (span.Length <= skipCount)
				{
					span = default(ReadOnlySpan<TSource>);
					return true;
				}
				int num = skipCount;
				span = span.Slice(0, span.Length - num);
				return true;
			}
			span = default(ReadOnlySpan<TSource>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TSource> destination, Index offset)
		{
			if (source.TryGetNonEnumeratedCount(out var count))
			{
				int num = Math.Min(count, skipCount);
				int num2 = count - num;
				if (num2 <= 0)
				{
					return false;
				}
				int offset2 = offset.GetOffset(num2);
				if (offset2 < 0 || offset2 >= num2)
				{
					return false;
				}
				int num3 = offset2;
				int num4 = Math.Min(num2 - offset2, destination.Length);
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
			if (skipCount == 0)
			{
				return source.TryGetNext(out current);
			}
			if (buffer == null)
			{
				buffer = new RefBox<ValueQueue<TSource>>(new ValueQueue<TSource>(4));
				TSource current2;
				while (buffer.GetValueRef().Count < skipCount && source.TryGetNext(out current2))
				{
					buffer.GetValueRef().Enqueue(current2);
				}
				if (buffer.GetValueRef().Count < skipCount)
				{
					Unsafe.SkipInit<TSource>(out current);
					return false;
				}
			}
			if (source.TryGetNext(out TSource current3))
			{
				current = buffer.GetValueRef().Dequeue();
				buffer.GetValueRef().Enqueue(current3);
				return true;
			}
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		public void Dispose()
		{
			buffer?.Dispose();
			source.Dispose();
		}
	}
}
