using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[Obsolete("Use ValueEnumerable.Sequence instead. This will be removed in a future version.")]
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
			this.end = end;
			this.step = step;
			this.rightBound = rightBound;
			value = start;
			first = true;
			forward = start < end;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = 0;
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
			if (first)
			{
				current = value;
				first = false;
				return true;
			}
			value += step;
			if (forward)
			{
				if (value < end || (rightBound == RightBound.Inclusive && value <= end))
				{
					current = value;
					return true;
				}
			}
			else if (value > end || (rightBound == RightBound.Inclusive && value >= end))
			{
				current = value;
				return true;
			}
			current = default(DateTimeOffset);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
