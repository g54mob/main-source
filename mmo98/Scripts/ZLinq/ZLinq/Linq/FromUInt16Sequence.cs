using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromUInt16Sequence : IValueEnumerator<ushort>, IDisposable
	{
		private bool calledGetNext;

		public FromUInt16Sequence(ushort currentValue, ushort endInclusive, ushort step, bool isIncrement)
		{
			_003CcurrentValue_003EP = currentValue;
			_003CendInclusive_003EP = endInclusive;
			_003Cstep_003EP = step;
			_003CisIncrement_003EP = isIncrement;
			calledGetNext = false;
		}

		public bool TryGetNext(out ushort current)
		{
			if (!calledGetNext)
			{
				calledGetNext = true;
				current = _003CcurrentValue_003EP;
				return true;
			}
			if (_003CisIncrement_003EP)
			{
				ushort num = (ushort)(_003CcurrentValue_003EP + _003Cstep_003EP);
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
			ushort num2 = (ushort)(_003CcurrentValue_003EP + _003Cstep_003EP);
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

		public bool TryGetSpan(out ReadOnlySpan<ushort> span)
		{
			span = default(ReadOnlySpan<ushort>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<ushort> destination, Index offset)
		{
			if (TryGetNonEnumeratedCount(out var count) && EnumeratorHelper.TryGetSliceRange(count, offset, destination.Length, out var start, out var count2))
			{
				FillIncremental(destination.Slice(0, count2), (ushort)(_003CcurrentValue_003EP + (ushort)start));
				return true;
			}
			return false;
		}

		private bool CanOptimize()
		{
			if (_003Cstep_003EP == 1 && _003CendInclusive_003EP - _003CcurrentValue_003EP + 1 <= 65535)
			{
				return true;
			}
			return false;
		}

		private static void FillIncremental(Span<ushort> span, ushort start)
		{
			ref ushort reference = ref MemoryMarshal.GetReference(span);
			ref ushort right = ref Unsafe.Add(ref reference, span.Length);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				reference = start++;
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}
}
