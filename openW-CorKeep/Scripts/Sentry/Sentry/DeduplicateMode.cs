using System;

namespace Sentry
{
	[Flags]
	public enum DeduplicateMode
	{
		SameEvent = 1,
		SameExceptionInstance = 2,
		InnerException = 4,
		AggregateException = 8,
		All = int.MaxValue
	}
}
