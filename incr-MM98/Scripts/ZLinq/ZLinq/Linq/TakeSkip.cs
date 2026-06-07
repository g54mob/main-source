using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct TakeSkip<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private readonly int takeCount;

		private readonly int skipCount;

		private int taken;

		private int skipped;

		private bool reachedTakeLimit;

		public TakeSkip(TEnumerator source, int takeCount, int skipCount)
		{
			taken = 0;
			skipped = 0;
			reachedTakeLimit = false;
			this.source = source;
			this.takeCount = Math.Max(0, takeCount);
			this.skipCount = Math.Max(0, skipCount);
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (source.TryGetNonEnumeratedCount(out count))
			{
				count = Math.Min(count, takeCount);
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
				int num = Math.Min(count, takeCount);
				int num2 = Math.Min(num, skipCount);
				int num3 = num - num2;
				if (num3 <= 0)
				{
					return false;
				}
				int offset2 = offset.GetOffset(num3);
				if (offset2 < 0 || offset2 >= num3)
				{
					return false;
				}
				int num4 = num2 + offset2;
				int num5 = Math.Min(num3 - offset2, destination.Length);
				if (num5 <= 0)
				{
					return false;
				}
				return source.TryCopyTo(destination.Slice(0, num5), num4);
			}
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			if (source.TryGetSpan(out span))
			{
				if (span.Length > takeCount)
				{
					span = span.Slice(0, takeCount);
				}
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
			if (IsResultEmpty())
			{
				Unsafe.SkipInit<TSource>(out current);
				return false;
			}
			if (reachedTakeLimit)
			{
				Unsafe.SkipInit<TSource>(out current);
				return false;
			}
			while (skipped < skipCount)
			{
				if (taken >= takeCount)
				{
					reachedTakeLimit = true;
					Unsafe.SkipInit<TSource>(out current);
					return false;
				}
				if (!source.TryGetNext(out TSource _))
				{
					Unsafe.SkipInit<TSource>(out current);
					return false;
				}
				taken++;
				if (taken >= takeCount)
				{
					reachedTakeLimit = true;
					Unsafe.SkipInit<TSource>(out current);
					return false;
				}
				skipped++;
			}
			if (taken >= takeCount)
			{
				reachedTakeLimit = true;
				Unsafe.SkipInit<TSource>(out current);
				return false;
			}
			if (source.TryGetNext(out current))
			{
				taken++;
				return true;
			}
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		private bool IsResultEmpty()
		{
			if (takeCount == 0)
			{
				return true;
			}
			if (skipCount >= takeCount)
			{
				return true;
			}
			return false;
		}

		public void Dispose()
		{
			source.Dispose();
		}

		internal TakeSkip<TEnumerator, TSource> Skip(int count)
		{
			if (count <= 0)
			{
				return this;
			}
			return new TakeSkip<TEnumerator, TSource>(skipCount: (count <= 0 || skipCount <= int.MaxValue - count) ? (skipCount + count) : int.MaxValue, source: source, takeCount: takeCount);
		}
	}
}
