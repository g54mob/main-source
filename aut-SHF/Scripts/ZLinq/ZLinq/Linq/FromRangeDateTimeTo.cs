using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromRangeDateTimeTo : IValueEnumerator<DateTime>, IDisposable
	{
		private readonly DateTime end;

		private readonly TimeSpan step;

		private readonly RightBound rightBound;

		private bool forward;

		private DateTime value;

		private bool first;

		public FromRangeDateTimeTo(DateTime start, DateTime end, TimeSpan step, RightBound rightBound)
		{
			this.end = default(DateTime);
			this.step = default(TimeSpan);
			this.rightBound = default(RightBound);
			forward = false;
			value = default(DateTime);
			first = false;
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
