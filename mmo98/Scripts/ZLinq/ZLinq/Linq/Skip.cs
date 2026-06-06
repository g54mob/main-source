using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Skip<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private readonly int skipCount;

		private int skipped;

		public Skip(TEnumerator source, int count)
		{
			skipped = 0;
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
				int num3 = num + offset2;
				int num4 = Math.Min(num2 - offset2, destination.Length);
				if (num4 <= 0)
				{
					return false;
				}
				return source.TryCopyTo(destination.Slice(0, num4), num3);
			}
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
				span = span.Slice(skipCount);
				return true;
			}
			span = default(ReadOnlySpan<TSource>);
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			while (skipped < skipCount)
			{
				if (!source.TryGetNext(out TSource _))
				{
					Unsafe.SkipInit<TSource>(out current);
					return false;
				}
				skipped++;
			}
			if (source.TryGetNext(out current))
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
	}
}
