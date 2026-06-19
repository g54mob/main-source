using System;
using System.Collections.Generic;

namespace FullSerializerSave.RuntimeTests
{
	public class NullableTimeSpanProvider : TestProvider<ValueHolder<TimeSpan?>>
	{
		public override bool Compare(ValueHolder<TimeSpan?> before, ValueHolder<TimeSpan?> after)
		{
			TimeSpan? value = before.Value;
			TimeSpan? value2 = after.Value;
			if (value.HasValue != value2.HasValue)
			{
				return false;
			}
			if (!value.HasValue)
			{
				return true;
			}
			return value.GetValueOrDefault() == value2.GetValueOrDefault();
		}

		public override IEnumerable<ValueHolder<TimeSpan?>> GetValues()
		{
			yield return new ValueHolder<TimeSpan?>(null);
			yield return new ValueHolder<TimeSpan?>(TimeSpan.FromSeconds(35.0));
		}
	}
}
