using System;

namespace JWT
{
	public interface IDateTimeProvider
	{
		DateTimeOffset GetNow();
	}
}
