using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Chunk<TEnumerator, TSource> : IValueEnumerator<TSource[]>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private int index;

		private bool isInitialized;

		private bool isCompleted;

		private bool isCanGetSpan;

		public Chunk(TEnumerator source, int size)
		{
			_003Csize_003EP = 0;
			this.source = default(TEnumerator);
			index = 0;
			isInitialized = false;
			isCompleted = false;
			isCanGetSpan = false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource[]> span)
		{
			span = default(ReadOnlySpan<TSource[]>);
			return false;
		}

		public bool TryCopyTo(Span<TSource[]> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out TSource[] current)
		{
			current = null;
			return false;
		}

		public void Dispose()
		{
		}
	}
}
