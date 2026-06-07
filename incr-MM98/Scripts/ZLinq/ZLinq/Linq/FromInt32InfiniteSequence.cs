using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromInt32InfiniteSequence : IValueEnumerator<int>, IDisposable
	{
		private bool calledGetNext;

		public FromInt32InfiniteSequence(int start, int step)
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

		public bool TryGetSpan(out ReadOnlySpan<int> span)
		{
			span = default(ReadOnlySpan<int>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<int> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out int current)
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
