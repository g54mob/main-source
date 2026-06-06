using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct WhereSelect<TEnumerator, TSource, TResult> : IValueEnumerator<TResult>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		internal Func<TSource, bool> Predicate => _003Cpredicate_003EP;

		internal Func<TSource, TResult> Selector => _003Cselector_003EP;

		public WhereSelect(TEnumerator source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
		{
			_003Cpredicate_003EP = predicate;
			_003Cselector_003EP = selector;
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

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<TResult> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			TSource current2;
			while (source.TryGetNext(out current2))
			{
				if (_003Cpredicate_003EP(current2))
				{
					current = _003Cselector_003EP(current2);
					return true;
				}
			}
			Unsafe.SkipInit<TResult>(out current);
			return false;
		}

		public void Dispose()
		{
			source.Dispose();
		}
	}
}
