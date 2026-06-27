using System;

namespace Castle.Core.Logging
{
	public interface ILoggerFactory
	{
		ILogger Create(Type type);

		ILogger Create(string name);

		ILogger Create(Type type, LoggerLevel level);

		ILogger Create(string name, LoggerLevel level);
	}
}
