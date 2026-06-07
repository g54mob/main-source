using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromSByteSequence : IValueEnumerator<sbyte>, IDisposable
	{
		private bool calledGetNext;

		public FromSByteSequence(sbyte currentValue, sbyte endInclusive, sbyte step, bool isIncrement)
		{
			_003CcurrentValue_003EP = currentValue;
			_003CendInclusive_003EP = endInclusive;
			_003Cstep_003EP = step;
			_003CisIncrement_003EP = isIncrement;
			calledGetNext = false;
		}

		public bool TryGetNext(out sbyte current)
		{
			if (!calledGetNext)
			{
				calledGetNext = true;
				current = _003CcurrentValue_003EP;
				return true;
			}
			if (_003CisIncrement_003EP)
			{
				sbyte b = (sbyte)(_003CcurrentValue_003EP + _003Cstep_003EP);
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
			sbyte b2 = (sbyte)(_003CcurrentValue_003EP + _003Cstep_003EP);
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

		public bool TryGetSpan(out ReadOnlySpan<sbyte> span)
		{
			span = default(ReadOnlySpan<sbyte>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<sbyte> destination, Index offset)
		{
			if (TryGetNonEnumeratedCount(out var count) && EnumeratorHelper.TryGetSliceRange(count, offset, destination.Length, out var start, out var count2))
			{
				FillIncremental(destination.Slice(0, count2), (sbyte)(_003CcurrentValue_003EP + (sbyte)start));
				return true;
			}
			return false;
		}

		private bool CanOptimize()
		{
			if (_003Cstep_003EP == 1 && _003CendInclusive_003EP - _003CcurrentValue_003EP + 1 <= 127)
			{
				return true;
			}
			return false;
		}

		private static void FillIncremental(Span<sbyte> span, sbyte start)
		{
			ref sbyte reference = ref MemoryMarshal.GetReference(span);
			ref sbyte right = ref Unsafe.Add(ref reference, span.Length);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				reference = start++;
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}
}
