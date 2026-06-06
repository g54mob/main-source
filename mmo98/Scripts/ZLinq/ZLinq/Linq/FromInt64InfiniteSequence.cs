using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromInt64InfiniteSequence : IValueEnumerator<long>, IDisposable
	{
		private bool calledGetNext;

		public FromInt64InfiniteSequence(long start, long step)
		{
			_003Cstart_003EP = start;
			_003Cstep_003EP = step;
			calledGetNext = false;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<long> span)
		{
			span = default(ReadOnlySpan<long>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<long> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out long current)
		{
			if (!calledGetNext)
			{
				calledGetNext = true;
				current = _003Cstart_003EP;
				return true;
			}
			current = (_003Cstart_003EP += _003Cstep_003EP);
			return true;
		}

		public void Dispose()
		{
		}
	}
}
