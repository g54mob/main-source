using System;

namespace Coherence.Common
{
	public class SystemDateTimeProvider : IDateTimeProvider
	{
		public static readonly SystemDateTimeProvider Instance;

		public DateTime UtcNow => default(DateTime);
	}
}
