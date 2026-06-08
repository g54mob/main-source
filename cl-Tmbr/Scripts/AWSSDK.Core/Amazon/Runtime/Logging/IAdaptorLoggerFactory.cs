using System;

namespace Amazon.Runtime.Logging
{
	public interface IAdaptorLoggerFactory
	{
		string Name { get; }

		IAdaptorLogger CreateAdaptorLogger(Type type);
	}
}
