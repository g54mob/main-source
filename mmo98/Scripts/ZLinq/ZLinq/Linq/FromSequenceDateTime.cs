using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromSequenceDateTime : IValueEnumerator<DateTime>, IDisposable
	{
		private bool calledGetNext;

		public FromSequenceDateTime(DateTime currentValue, DateTime endInclusive, TimeSpan step, bool isIncrement)
		{
			_003CcurrentValue_003EP = currentValue;
			_003CendInclusive_003EP = endInclusive;
			_003Cstep_003EP = step;
			_003CisIncrement_003EP = isIncrement;
			calledGetNext = false;
		}

		public bool TryGetNext(out DateTime current)
		{
			if (!calledGetNext)
			{
				calledGetNext = true;
				current = _003CcurrentValue_003EP;
				return true;
			}
			if (_003CisIncrement_003EP)
			{
				DateTime dateTime = _003CcurrentValue_003EP + _003Cstep_003EP;
				if (dateTime >= _003CendInclusive_003EP || dateTime <= _003CcurrentValue_003EP)
				{
					if (dateTime == _003CendInclusive_003EP && _003CcurrentValue_003EP != dateTime)
					{
						current = (_003CcurrentValue_003EP = dateTime);
						return true;
					}
					current = default(DateTime);
					return false;
				}
				current = (_003CcurrentValue_003EP = dateTime);
				return true;
			}
			DateTime dateTime2 = _003CcurrentValue_003EP + _003Cstep_003EP;
			if (dateTime2 <= _003CendInclusive_003EP || dateTime2 >= _003CcurrentValue_003EP)
			{
				if (dateTime2 == _003CendInclusive_003EP && _003CcurrentValue_003EP != dateTime2)
				{
					current = (_003CcurrentValue_003EP = dateTime2);
					return true;
				}
				current = default(DateTime);
				return false;
			}
			current = (_003CcurrentValue_003EP = dateTime2);
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

		public bool TryGetSpan(out ReadOnlySpan<DateTime> span)
		{
			span = default(ReadOnlySpan<DateTime>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<DateTime> destination, Index offset)
		{
			return false;
		}
	}
}
