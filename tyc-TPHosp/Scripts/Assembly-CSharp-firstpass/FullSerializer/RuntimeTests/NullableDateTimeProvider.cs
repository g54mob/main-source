using System;
using System.Collections.Generic;

namespace FullSerializer.RuntimeTests
{
	public class NullableDateTimeProvider : TestProvider<ValueHolder<DateTime?>>
	{
		public override bool Compare(ValueHolder<DateTime?> before, ValueHolder<DateTime?> after)
		{
			DateTime? value = before.Value;
			DateTime? value2 = after.Value;
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

		public override IEnumerable<ValueHolder<DateTime?>> GetValues()
		{
			yield return new ValueHolder<DateTime?>(null);
			yield return new ValueHolder<DateTime?>(DateTime.UtcNow);
		}
	}
}
