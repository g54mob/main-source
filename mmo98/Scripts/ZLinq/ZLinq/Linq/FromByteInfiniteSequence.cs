using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromByteInfiniteSequence : IValueEnumerator<byte>, IDisposable
	{
		private bool calledGetNext;

		public FromByteInfiniteSequence(byte start, byte step)
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

		public bool TryGetSpan(out ReadOnlySpan<byte> span)
		{
			span = default(ReadOnlySpan<byte>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<byte> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out byte current)
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
