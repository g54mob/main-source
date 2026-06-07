using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct SkipWhile2<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private bool skippingDone;

		private int index;

		public SkipWhile2(TEnumerator source, Func<TSource, int, bool> predicate)
		{
			_003Cpredicate_003EP = predicate;
			this.source = source;
			skippingDone = false;
			index = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
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
			if (skippingDone)
			{
				if (source.TryGetNext(out current))
				{
					index++;
					return true;
				}
				Unsafe.SkipInit<TSource>(out current);
				return false;
			}
			while (source.TryGetNext(out current))
			{
				if (!_003Cpredicate_003EP(current, index))
				{
					skippingDone = true;
					index++;
					return true;
				}
				index++;
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
