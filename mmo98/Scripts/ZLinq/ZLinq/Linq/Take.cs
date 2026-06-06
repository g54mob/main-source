using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Take<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		internal readonly int takeCount;

		private int index;

		public Take(TEnumerator source, int count)
		{
			index = 0;
			this.source = source;
			takeCount = Math.Max(0, count);
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
				span = span.Slice(0, Math.Min(span.Length, takeCount));
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
				int offset2 = offset.GetOffset(num);
				if (offset2 < 0 || offset2 >= num)
				{
					return false;
				}
				int length = Math.Min(offset.IsFromEnd ? offset.Value : (num - offset2), destination.Length);
				return source.TryCopyTo(destination.Slice(0, length), offset2);
			}
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			if (index++ < takeCount && source.TryGetNext(out current))
			{
				return true;
			}
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		public void Dispose()
		{
			source.Dispose();
		}

		internal TakeSkip<TEnumerator, TSource> Skip(int skipCount)
		{
			return new TakeSkip<TEnumerator, TSource>(source, takeCount, skipCount);
		}
	}
}
