using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromByteSequence : IValueEnumerator<byte>, IDisposable
	{
		private bool calledGetNext;

		public FromByteSequence(byte currentValue, byte endInclusive, byte step, bool isIncrement)
		{
			_003CcurrentValue_003EP = currentValue;
			_003CendInclusive_003EP = endInclusive;
			_003Cstep_003EP = step;
			_003CisIncrement_003EP = isIncrement;
			calledGetNext = false;
		}

		public bool TryGetNext(out byte current)
		{
			if (!calledGetNext)
			{
				calledGetNext = true;
				current = _003CcurrentValue_003EP;
				return true;
			}
			if (_003CisIncrement_003EP)
			{
				byte b = (byte)(_003CcurrentValue_003EP + _003Cstep_003EP);
				if (b >= _003CendInclusive_003EP || b <= _003CcurrentValue_003EP)
				{
					if (b == _003CendInclusive_003EP && _003CcurrentValue_003EP != b)
					{
						current = (_003CcurrentValue_003EP = b);
						return true;
					}
					current = 0;
					return false;
				}
				current = (_003CcurrentValue_003EP = b);
				return true;
			}
			byte b2 = (byte)(_003CcurrentValue_003EP + _003Cstep_003EP);
			if (b2 <= _003CendInclusive_003EP || b2 >= _003CcurrentValue_003EP)
			{
				if (b2 == _003CendInclusive_003EP && _003CcurrentValue_003EP != b2)
				{
					current = (_003CcurrentValue_003EP = b2);
					return true;
				}
				current = 0;
				return false;
			}
			current = (_003CcurrentValue_003EP = b2);
			return true;
		}

		public void Dispose()
		{
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (CanOptimize())
			{
				count = _003CendInclusive_003EP - _003CcurrentValue_003EP + 1;
				return true;
			}
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
			if (TryGetNonEnumeratedCount(out var count) && EnumeratorHelper.TryGetSliceRange(count, offset, destination.Length, out var start, out var count2))
			{
				FillIncremental(destination.Slice(0, count2), (byte)(_003CcurrentValue_003EP + (byte)start));
				return true;
			}
			return false;
		}

		private bool CanOptimize()
		{
			if (_003Cstep_003EP == 1 && _003CendInclusive_003EP - _003CcurrentValue_003EP + 1 <= 255)
			{
				return true;
			}
			return false;
		}

		private static void FillIncremental(Span<byte> span, byte start)
		{
			ref byte reference = ref MemoryMarshal.GetReference(span);
			ref byte right = ref Unsafe.Add(ref reference, span.Length);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				reference = start++;
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}
}
