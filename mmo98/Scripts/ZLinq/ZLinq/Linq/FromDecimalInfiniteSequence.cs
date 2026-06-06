using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromDecimalInfiniteSequence : IValueEnumerator<decimal>, IDisposable
	{
		private bool calledGetNext;

		public FromDecimalInfiniteSequence(decimal start, decimal step)
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

		public bool TryGetSpan(out ReadOnlySpan<decimal> span)
		{
			span = default(ReadOnlySpan<decimal>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<decimal> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out decimal current)
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
