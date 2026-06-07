using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Where<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		internal Func<TSource, bool> Predicate => null;

		public Where(TEnumerator source, Func<TSource, bool> predicate)
		{
			_003Cpredicate_003EP = null;
			this.source = default(TEnumerator);
		}

		internal TEnumerator GetSource()
		{
			return default(TEnumerator);
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			span = default(ReadOnlySpan<TSource>);
			return false;
		}

		public bool TryCopyTo(Span<TSource> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			current = default(TSource);
			return false;
		}

		public void Dispose()
		{
		}

		internal WhereSelect<TEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) where TResult : notnull
		{
			return default(WhereSelect<TEnumerator, TSource, TResult>);
		}
	}
}
