using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct ArrayWhereSelect<TSource, TResult> : IValueEnumerator<TResult>, IDisposable where TSource : notnull where TResult : notnull
	{
		private int index;

		private TSource[] source;

		internal Func<TSource, bool> Predicate => null;

		internal Func<TSource, TResult> Selector => null;

		public ArrayWhereSelect(TSource[] source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
		{
			_003Cpredicate_003EP = null;
			_003Cselector_003EP = null;
			index = 0;
			this.source = null;
		}

		internal TSource[] GetSource()
		{
			return null;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TResult> span)
		{
			span = default(ReadOnlySpan<TResult>);
			return false;
		}

		public bool TryCopyTo(Span<TResult> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TResult current)
		{
			current = default(TResult);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
