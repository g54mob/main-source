using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromRange : IValueEnumerator<int>, IDisposable
	{
		internal readonly int count;

		internal readonly int start;

		internal readonly int to;

		private int value;

		public FromRange(int start, int count)
		{
			this.count = 0;
			this.start = 0;
			to = 0;
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

		internal static void FillIncremental(Span<int> span, int start)
		{
		}
	}
}
