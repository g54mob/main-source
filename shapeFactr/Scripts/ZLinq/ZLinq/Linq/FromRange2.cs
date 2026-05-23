using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromRange2 : IValueEnumerator<int>, IDisposable
	{
		private readonly int count;

		private readonly int start;

		private readonly int to;

		private readonly bool isInfinite;

		private int value;

		public FromRange2(int start, int count, bool isInfinite)
		{
			this.count = 0;
			this.start = 0;
			to = 0;
			this.isInfinite = false;
			value = 0;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<int> span)
		{
			span = default(ReadOnlySpan<int>);
			return false;
		}

		public bool TryCopyTo(Span<int> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out int current)
		{
			current = default(int);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
