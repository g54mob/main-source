using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Index<TEnumerator, TSource> : IValueEnumerator<(int, TSource)>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private int index;

		public Index(TEnumerator source)
		{
			this.source = default(TEnumerator);
			index = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<(int Index, TSource Item)> span)
		{
			span = default(ReadOnlySpan<(int, TSource)>);
			return false;
		}

		public bool TryCopyTo(Span<(int Index, TSource Item)> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out (int Index, TSource Item) current)
		{
			current = default((int, TSource));
			return false;
		}

		public void Dispose()
		{
		}
	}
}
