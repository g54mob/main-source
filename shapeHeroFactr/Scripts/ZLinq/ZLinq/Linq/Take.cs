using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Take<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		internal readonly int takeCount;

		private int index;

		public Take(TEnumerator source, int count)
		{
			this.source = default(TEnumerator);
			takeCount = 0;
			index = 0;
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

		internal TakeSkip<TEnumerator, TSource> Skip(int skipCount)
		{
			return default(TakeSkip<TEnumerator, TSource>);
		}
	}
}
