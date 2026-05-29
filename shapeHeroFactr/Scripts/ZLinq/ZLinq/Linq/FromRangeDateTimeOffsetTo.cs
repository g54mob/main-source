using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout((LayoutKind)3)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromRangeDateTimeOffsetTo : IValueEnumerator<DateTimeOffset>, IDisposable
	{
		private readonly DateTimeOffset end;

		private readonly TimeSpan step;

		private readonly RightBound rightBound;

		private DateTimeOffset value;

		private bool first;

		private bool forward;

		public FromRangeDateTimeOffsetTo(DateTimeOffset start, DateTimeOffset end, TimeSpan step, RightBound rightBound)
		{
			this.end = default(DateTimeOffset);
			this.step = default(TimeSpan);
			this.rightBound = default(RightBound);
			value = default(DateTimeOffset);
			first = false;
			forward = false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = default(int);
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<DateTimeOffset> span)
		{
			span = default(ReadOnlySpan<DateTimeOffset>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<DateTimeOffset> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out DateTimeOffset current)
		{
			current = default(DateTimeOffset);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
