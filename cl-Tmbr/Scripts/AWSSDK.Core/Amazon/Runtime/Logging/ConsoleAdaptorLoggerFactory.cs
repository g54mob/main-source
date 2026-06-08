using System;

namespace Amazon.Runtime.Logging
{
	internal class ConsoleAdaptorLoggerFactory : IAdaptorLoggerFactory
	{
		public string Name { get; } = "Console";

		public IAdaptorLogger CreateAdaptorLogger(Type type)
		{
			return new ConsoleAdaptorLogger(type);
		}
	}
}
