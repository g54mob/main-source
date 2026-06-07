using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromRangeDateTimeOffset : IValueEnumerator<DateTimeOffset>, IDisposable
	{
		private readonly int count;

		private readonly TimeSpan timeSpan;

		private int index;

		private DateTimeOffset value;

		public FromRangeDateTimeOffset(DateTimeOffset start, int count, TimeSpan step)
		{
			_003Cstep_003EP = step;
			this.count = count;
			timeSpan = _003Cstep_003EP;
			index = 0;
			value = start;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = this.count;
			return true;
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
			if (index < count)
			{
				if (index != 0)
				{
					value += _003Cstep_003EP;
				}
				current = value;
				index++;
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
