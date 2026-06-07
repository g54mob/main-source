using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct FromSequenceDateTimeOffset : IValueEnumerator<DateTimeOffset>, IDisposable
	{
		private bool calledGetNext;

		public FromSequenceDateTimeOffset(DateTimeOffset currentValue, DateTimeOffset endInclusive, TimeSpan step, bool isIncrement)
		{
			_003CcurrentValue_003EP = currentValue;
			_003CendInclusive_003EP = endInclusive;
			_003Cstep_003EP = step;
			_003CisIncrement_003EP = isIncrement;
			calledGetNext = false;
		}

		public bool TryGetNext(out DateTimeOffset current)
		{
			if (!calledGetNext)
			{
				calledGetNext = true;
				current = _003CcurrentValue_003EP;
				return true;
			}
			if (_003CisIncrement_003EP)
			{
				DateTimeOffset dateTimeOffset = _003CcurrentValue_003EP + _003Cstep_003EP;
				if (dateTimeOffset >= _003CendInclusive_003EP || dateTimeOffset <= _003CcurrentValue_003EP)
				{
					if (dateTimeOffset == _003CendInclusive_003EP && _003CcurrentValue_003EP != dateTimeOffset)
					{
						current = (_003CcurrentValue_003EP = dateTimeOffset);
						return true;
					}
					current = default(DateTimeOffset);
					return false;
				}
				current = (_003CcurrentValue_003EP = dateTimeOffset);
				return true;
			}
			DateTimeOffset dateTimeOffset2 = _003CcurrentValue_003EP + _003Cstep_003EP;
			if (dateTimeOffset2 <= _003CendInclusive_003EP || dateTimeOffset2 >= _003CcurrentValue_003EP)
			{
				if (dateTimeOffset2 == _003CendInclusive_003EP && _003CcurrentValue_003EP != dateTimeOffset2)
				{
					current = (_003CcurrentValue_003EP = dateTimeOffset2);
					return true;
				}
				current = default(DateTimeOffset);
				return false;
			}
			current = (_003CcurrentValue_003EP = dateTimeOffset2);
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

		public bool TryGetSpan(out ReadOnlySpan<DateTimeOffset> span)
		{
			span = default(ReadOnlySpan<DateTimeOffset>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<DateTimeOffset> destination, Index offset)
		{
			return false;
		}
	}
}
