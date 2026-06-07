using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct TakeRange<TEnumerator, TSource> : IValueEnumerator<TSource>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private readonly Range range;

		private int index;

		private int remains;

		private int skipIndex;

		private int fromEndQueueCount;

		private RefBox<ValueQueue<TSource>>? q;

		private bool isInitialized;

		public TakeRange(TEnumerator source, Range range)
		{
			this.source = default(TEnumerator);
			this.range = default(Range);
			index = 0;
			remains = 0;
			skipIndex = 0;
			fromEndQueueCount = 0;
			q = null;
			isInitialized = false;
		}

		private void Init()
		{
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
