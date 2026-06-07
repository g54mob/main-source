using System;

namespace Coherence.Common
{
	public interface IDateTimeProvider
	{
		DateTime UtcNow { get; }
	}
}
