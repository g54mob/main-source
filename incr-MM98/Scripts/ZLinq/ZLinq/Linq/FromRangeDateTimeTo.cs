using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[Obsolete("Use ValueEnumerable.Sequence instead. This will be removed in a future version.")]
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
			this.end = end;
			this.step = step;
			this.rightBound = rightBound;
			forward = start < end;
			value = start;
			first = true;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = 0;
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
			current = default(DateTime);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
