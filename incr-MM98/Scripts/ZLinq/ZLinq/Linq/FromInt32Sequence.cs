using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromInt32Sequence : IValueEnumerator<int>, IDisposable
	{
		private bool calledGetNext;

		public FromInt32Sequence(int currentValue, int endInclusive, int step, bool isIncrement)
		{
			_003CcurrentValue_003EP = currentValue;
			_003CendInclusive_003EP = endInclusive;
			_003Cstep_003EP = step;
			_003CisIncrement_003EP = isIncrement;
			calledGetNext = false;
		}

		public bool TryGetNext(out int current)
		{
			if (!calledGetNext)
			{
				calledGetNext = true;
				current = _003CcurrentValue_003EP;
				return true;
			}
			if (_003CisIncrement_003EP)
			{
				int num = _003CcurrentValue_003EP + _003Cstep_003EP;
				if (num >= _003CendInclusive_003EP || num <= _003CcurrentValue_003EP)
				{
					if (num == _003CendInclusive_003EP && _003CcurrentValue_003EP != num)
					{
						current = (_003CcurrentValue_003EP = num);
						return true;
					}
					current = 0;
					return false;
				}
				current = (_003CcurrentValue_003EP = num);
				return true;
			}
			int num2 = _003CcurrentValue_003EP + _003Cstep_003EP;
			if (num2 <= _003CendInclusive_003EP || num2 >= _003CcurrentValue_003EP)
			{
				if (num2 == _003CendInclusive_003EP && _003CcurrentValue_003EP != num2)
				{
					current = (_003CcurrentValue_003EP = num2);
					return true;
				}
				current = 0;
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
				count = _003CendInclusive_003EP - _003CcurrentValue_003EP + 1;
				return true;
			}
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
			if (TryGetNonEnumeratedCount(out var count) && EnumeratorHelper.TryGetSliceRange(count, offset, destination.Length, out var start, out var count2))
			{
				FillIncremental(destination.Slice(0, count2), _003CcurrentValue_003EP + start);
				return true;
			}
			return false;
		}

		private bool CanOptimize()
		{
			if (_003Cstep_003EP == 1 && _003CendInclusive_003EP - _003CcurrentValue_003EP + 1 <= int.MaxValue)
			{
				return true;
			}
			return false;
		}

		private static void FillIncremental(Span<int> span, int start)
		{
			ref int reference = ref MemoryMarshal.GetReference(span);
			ref int right = ref Unsafe.Add(ref reference, span.Length);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				reference = start++;
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}
}
