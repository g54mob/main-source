using System;

namespace Castle.Core.Logging
{
	public interface IExtendedLoggerFactory : ILoggerFactory
	{
		new IExtendedLogger Create(Type type);

		new IExtendedLogger Create(string name);

		new IExtendedLogger Create(Type type, LoggerLevel level);

		new IExtendedLogger Create(string name, LoggerLevel level);
	}
}
