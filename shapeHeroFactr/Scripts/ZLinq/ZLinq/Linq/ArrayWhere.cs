using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct ArrayWhere<TSource> : IValueEnumerator<TSource>, IDisposable where TSource : notnull
	{
		private TSource[] source;

		private int index;

		internal Func<TSource, bool> Predicate => null;

		public ArrayWhere(FromArray<TSource> source, Func<TSource, bool> predicate)
		{
			_003Cpredicate_003EP = null;
			this.source = null;
			index = 0;
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

		public ArrayWhereSelect<TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) where TResult : notnull
		{
			return default(ArrayWhereSelect<TSource, TResult>);
		}
	}
}
