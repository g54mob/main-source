using System;

namespace FluentAssertions.Common
{
	public interface ITimer : IDisposable
	{
		TimeSpan Elapsed { get; }
	}
}
