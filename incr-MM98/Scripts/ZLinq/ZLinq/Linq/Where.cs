using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Where<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		internal Func<TSource, bool> Predicate => _003Cpredicate_003EP;

		public Where(TEnumerator source, Func<TSource, bool> predicate)
		{
			_003Cpredicate_003EP = predicate;
			this.source = source;
		}

		internal TEnumerator GetSource()
		{
			return source;
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
			TSource current2;
			while (source.TryGetNext(out current2))
			{
				if (_003Cpredicate_003EP(current2))
				{
					current = current2;
					return true;
				}
			}
			Unsafe.SkipInit<TSource>(out current);
			return false;
		}

		public void Dispose()
		{
			source.Dispose();
		}

		internal WhereSelect<TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
		{
			return new WhereSelect<TEnumerator, TSource, TResult>(source, _003Cpredicate_003EP, selector);
		}
	}
}
