using System;

namespace JWT
{
	public sealed class UtcDateTimeProvider : IDateTimeProvider
	{
		public DateTimeOffset GetNow()
		{
			return default(DateTimeOffset);
		}
	}
}
