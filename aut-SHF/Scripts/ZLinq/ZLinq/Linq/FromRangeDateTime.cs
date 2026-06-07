using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromRangeDateTime : IValueEnumerator<DateTime>, IDisposable
	{
		private readonly int count;

		private readonly TimeSpan timeSpan;

		private int index;

		private DateTime value;

		public FromRangeDateTime(DateTime start, int count, TimeSpan step)
		{
			_003Cstep_003EP = default(TimeSpan);
			this.count = 0;
			timeSpan = default(TimeSpan);
			index = 0;
			value = default(DateTime);
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<DateTime> span)
		{
			span = default(ReadOnlySpan<DateTime>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<DateTime> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out DateTime current)
		{
			current = default(DateTime);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
