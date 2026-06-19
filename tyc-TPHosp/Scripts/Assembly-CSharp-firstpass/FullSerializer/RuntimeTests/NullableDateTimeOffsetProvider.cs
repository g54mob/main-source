using System;
using System.Collections.Generic;

namespace FullSerializer.RuntimeTests
{
	public class NullableDateTimeOffsetProvider : TestProvider<ValueHolder<DateTimeOffset?>>
	{
		public override bool Compare(ValueHolder<DateTimeOffset?> before, ValueHolder<DateTimeOffset?> after)
		{
			DateTimeOffset? value = before.Value;
			DateTimeOffset? value2 = after.Value;
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

		public override IEnumerable<ValueHolder<DateTimeOffset?>> GetValues()
		{
			yield return new ValueHolder<DateTimeOffset?>(null);
			yield return new ValueHolder<DateTimeOffset?>(DateTimeOffset.UtcNow);
		}
	}
}
