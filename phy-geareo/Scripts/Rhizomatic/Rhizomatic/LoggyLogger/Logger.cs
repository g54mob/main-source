using System;
using System.Collections.Generic;

namespace Rhizomatic.LoggyLogger
{
	public class Logger
	{
		public List<Transport> transports;

		public string dataPath;

		public Logger()
		{
		}

		public Logger(params Transport[] transports)
		{
		}

		public Logger AddTransport(Transport transport)
		{
			return null;
		}

		public Logger AddTransport(Action<Log> onLog)
		{
			return null;
		}

		public void Dispose()
		{
		}

		public void Log(Log log)
		{
		}

		public void Log(string message, object data = null)
		{
		}

		public void LogInfo(string message, object data = null)
		{
		}

		public void LogWarn(string message, object data = null)
		{
		}

		public void LogError(string message, object data = null)
		{
		}

		public void LogError(Exception exception, object data = null)
		{
		}

		public void LogFatal(string message, object data = null)
		{
		}

		public void LogFatal(Exception exception, object data = null)
		{
		}
	}
}
