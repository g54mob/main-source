using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromUInt32Sequence : IValueEnumerator<uint>, IDisposable
	{
		private bool calledGetNext;

		public FromUInt32Sequence(uint currentValue, uint endInclusive, uint step, bool isIncrement)
		{
			_003CcurrentValue_003EP = currentValue;
			_003CendInclusive_003EP = endInclusive;
			_003Cstep_003EP = step;
			_003CisIncrement_003EP = isIncrement;
			calledGetNext = false;
		}

		public bool TryGetNext(out uint current)
		{
			if (!calledGetNext)
			{
				calledGetNext = true;
				current = _003CcurrentValue_003EP;
				return true;
			}
			if (_003CisIncrement_003EP)
			{
				uint num = _003CcurrentValue_003EP + _003Cstep_003EP;
				if (num >= _003CendInclusive_003EP || num <= _003CcurrentValue_003EP)
				{
					if (num == _003CendInclusive_003EP && _003CcurrentValue_003EP != num)
					{
						current = (_003CcurrentValue_003EP = num);
						return true;
					}
					current = 0u;
					return false;
				}
				current = (_003CcurrentValue_003EP = num);
				return true;
			}
			uint num2 = _003CcurrentValue_003EP + _003Cstep_003EP;
			if (num2 <= _003CendInclusive_003EP || num2 >= _003CcurrentValue_003EP)
			{
				if (num2 == _003CendInclusive_003EP && _003CcurrentValue_003EP != num2)
				{
					current = (_003CcurrentValue_003EP = num2);
					return true;
				}
				current = 0u;
				return false;
			}
			current = (_003CcurrentValue_003EP = num2);
			return true;
		}

		public void Dispose()
		{
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			if (CanOptimize())
			{
				count = (int)(_003CendInclusive_003EP - _003CcurrentValue_003EP + 1);
				return true;
			}
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<uint> span)
		{
			span = default(ReadOnlySpan<uint>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<uint> destination, Index offset)
		{
			if (TryGetNonEnumeratedCount(out var count) && EnumeratorHelper.TryGetSliceRange(count, offset, destination.Length, out var start, out var count2))
			{
				FillIncremental(destination.Slice(0, count2), _003CcurrentValue_003EP + (uint)start);
				return true;
			}
			return false;
		}

		private bool CanOptimize()
		{
			if (_003Cstep_003EP == 1 && _003CendInclusive_003EP - _003CcurrentValue_003EP + 1 <= uint.MaxValue)
			{
				return true;
			}
			return false;
		}

		private static void FillIncremental(Span<uint> span, uint start)
		{
			ref uint reference = ref MemoryMarshal.GetReference(span);
			ref uint right = ref Unsafe.Add(ref reference, span.Length);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				reference = start++;
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}
}
