using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct TakeSkip<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private readonly int takeCount;

		private readonly int skipCount;

		private int taken;

		private int skipped;

		private bool reachedTakeLimit;

		public TakeSkip(TEnumerator source, int takeCount, int skipCount)
		{
			this.source = default(TEnumerator);
			this.takeCount = 0;
			this.skipCount = 0;
			taken = 0;
			skipped = 0;
			reachedTakeLimit = false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryCopyTo(Span<TSource> destination, Index offset)
		{
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<TSource> span)
		{
			span = default(ReadOnlySpan<TSource>);
			return false;
		}

		public bool TryGetNext(out TSource current)
		{
			current = default(TSource);
			return false;
		}

		private bool IsResultEmpty()
		{
			return false;
		}

		public void Dispose()
		{
		}

		internal TakeSkip<TEnumerator, TSource> Skip(int count)
		{
			return default(TakeSkip<TEnumerator, TSource>);
		}
	}
}
