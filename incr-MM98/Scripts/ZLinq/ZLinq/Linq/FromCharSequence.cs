using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromCharSequence : IValueEnumerator<char>, IDisposable
	{
		private bool calledGetNext;

		public FromCharSequence(char currentValue, char endInclusive, char step, bool isIncrement)
		{
			_003CcurrentValue_003EP = currentValue;
			_003CendInclusive_003EP = endInclusive;
			_003Cstep_003EP = step;
			_003CisIncrement_003EP = isIncrement;
			calledGetNext = false;
		}

		public bool TryGetNext(out char current)
		{
			if (!calledGetNext)
			{
				calledGetNext = true;
				current = _003CcurrentValue_003EP;
				return true;
			}
			if (_003CisIncrement_003EP)
			{
				char c = (char)(_003CcurrentValue_003EP + _003Cstep_003EP);
				if (c >= _003CendInclusive_003EP || c <= _003CcurrentValue_003EP)
				{
					if (c == _003CendInclusive_003EP && _003CcurrentValue_003EP != c)
					{
						current = (_003CcurrentValue_003EP = c);
						return true;
					}
					current = '\0';
					return false;
				}
				current = (_003CcurrentValue_003EP = c);
				return true;
			}
			char c2 = (char)(_003CcurrentValue_003EP + _003Cstep_003EP);
			if (c2 <= _003CendInclusive_003EP || c2 >= _003CcurrentValue_003EP)
			{
				if (c2 == _003CendInclusive_003EP && _003CcurrentValue_003EP != c2)
				{
					current = (_003CcurrentValue_003EP = c2);
					return true;
				}
				current = '\0';
				return false;
			}
			current = (_003CcurrentValue_003EP = c2);
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

		public bool TryGetSpan(out ReadOnlySpan<char> span)
		{
			span = default(ReadOnlySpan<char>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<char> destination, Index offset)
		{
			if (TryGetNonEnumeratedCount(out var count) && EnumeratorHelper.TryGetSliceRange(count, offset, destination.Length, out var start, out var count2))
			{
				FillIncremental(destination.Slice(0, count2), (char)(_003CcurrentValue_003EP + (ushort)start));
				return true;
			}
			return false;
		}

		private bool CanOptimize()
		{
			if (_003Cstep_003EP == '\u0001' && _003CendInclusive_003EP - _003CcurrentValue_003EP + 1 <= 65535)
			{
				return true;
			}
			return false;
		}

		private static void FillIncremental(Span<char> span, char start)
		{
			ref char reference = ref MemoryMarshal.GetReference(span);
			ref char right = ref Unsafe.Add(ref reference, span.Length);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				reference = start++;
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}
}
