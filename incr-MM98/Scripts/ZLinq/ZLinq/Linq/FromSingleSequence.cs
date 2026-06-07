using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromSingleSequence : IValueEnumerator<float>, IDisposable
	{
		private bool calledGetNext;

		public FromSingleSequence(float currentValue, float endInclusive, float step, bool isIncrement)
		{
			_003CcurrentValue_003EP = currentValue;
			_003CendInclusive_003EP = endInclusive;
			_003Cstep_003EP = step;
			_003CisIncrement_003EP = isIncrement;
			calledGetNext = false;
		}

		public bool TryGetNext(out float current)
		{
			if (!calledGetNext)
			{
				calledGetNext = true;
				current = _003CcurrentValue_003EP;
				return true;
			}
			if (_003CisIncrement_003EP)
			{
				float num = _003CcurrentValue_003EP + _003Cstep_003EP;
				if (num >= _003CendInclusive_003EP || num <= _003CcurrentValue_003EP)
				{
					if (num == _003CendInclusive_003EP && _003CcurrentValue_003EP != num)
					{
						current = (_003CcurrentValue_003EP = num);
						return true;
					}
					current = 0f;
					return false;
				}
				current = (_003CcurrentValue_003EP = num);
				return true;
			}
			float num2 = _003CcurrentValue_003EP + _003Cstep_003EP;
			if (num2 <= _003CendInclusive_003EP || num2 >= _003CcurrentValue_003EP)
			{
				if (num2 == _003CendInclusive_003EP && _003CcurrentValue_003EP != num2)
				{
					current = (_003CcurrentValue_003EP = num2);
					return true;
				}
				current = 0f;
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
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<float> span)
		{
			span = default(ReadOnlySpan<float>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<float> destination, Index offset)
		{
			return false;
		}
	}
}
