using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Concat<TEnumerator1, TEnumerator2, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator1 : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
	{
		private TEnumerator1 first;

		private TEnumerator2 second;

		private bool firstCompleted;

		public Concat(TEnumerator1 first, TEnumerator2 second)
		{
			this.first = default(TEnumerator1);
			this.second = default(TEnumerator2);
			firstCompleted = false;
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
	}
}
