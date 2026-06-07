using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Concat<TEnumerator1, TEnumerator2, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator1 : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
	{
		private TEnumerator1 first;

		private TEnumerator2 second;

		private bool firstCompleted;

		public Concat(TEnumerator1 first, TEnumerator2 second)
		{
			firstCompleted = false;
			this.first = first;
			this.second = second;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (first.TryGetNonEnumeratedCount(out var count2) && second.TryGetNonEnumeratedCount(out var count3))
			{
				count = checked(count2 + count3);
				return true;
			}
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			span = default(ReadOnlySpan<TSource>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TSource> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			if (!firstCompleted)
			{
				if (first.TryGetNext(out current))
				{
					return true;
				}
				first.Dispose();
				firstCompleted = true;
			}
			if (second.TryGetNext(out current))
			{
				return true;
			}
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		public void Dispose()
		{
			if (!firstCompleted)
			{
				first.Dispose();
			}
			second.Dispose();
		}
	}
}
