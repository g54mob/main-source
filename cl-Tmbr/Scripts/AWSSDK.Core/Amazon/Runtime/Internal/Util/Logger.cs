using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Amazon.Runtime.Logging;

namespace Amazon.Runtime.Internal.Util
{
	public class Logger : ILogger
	{
		private static readonly ConcurrentDictionary<string, IAdaptorLoggerFactory> _adaptorFactories = new ConcurrentDictionary<string, IAdaptorLoggerFactory>();

		private static readonly ConcurrentDictionary<Type, Logger> _cachedLoggers = new ConcurrentDictionary<Type, Logger>();

		private List<IAdaptorLogger> _loggers;

		private static Logger emptyLogger = new Logger();

		public static Logger EmptyLogger => emptyLogger;

		private Logger()
		{
			_loggers = new List<IAdaptorLogger>();
		}

		private Logger(Type type)
		{
			_loggers = new List<IAdaptorLogger>();
			foreach (IAdaptorLoggerFactory value in _adaptorFactories.Values)
			{
				_loggers.Add(value.CreateAdaptorLogger(type));
			}
		}

		internal static void RegisterAdaptorLoggerFactory(IAdaptorLoggerFactory factory)
		{
			_adaptorFactories.AddOrUpdate(factory.Name, factory, (string key, IAdaptorLoggerFactory oldValue) => factory);
			_cachedLoggers.Clear();
		}

		internal static void DeregisterAdaptorLoggerFactory(string factoryName)
		{
			if (_adaptorFactories.TryRemove(factoryName, out var _))
			{
				_cachedLoggers.Clear();
			}
		}

		public static Logger GetLogger(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			Logger value;
			lock (_cachedLoggers)
			{
				if (!_cachedLoggers.TryGetValue(type, out value))
				{
					value = new Logger(type);
					_cachedLoggers[type] = value;
				}
			}
			return value;
		}

		public static void ClearLoggerCache()
		{
			_cachedLoggers.Clear();
		}

		public void Error(Exception exception, string messageFormat, params object[] args)
		{
			foreach (IAdaptorLogger logger in _loggers)
			{
				if (logger.IsEnabled(SdkLogLevel.Error))
				{
					logger.Log(SdkLogLevel.Error, messageFormat, exception, args);
				}
			}
		}

		public void Debug(Exception exception, string messageFormat, params object[] args)
		{
			foreach (IAdaptorLogger logger in _loggers)
			{
				if (logger.IsEnabled(SdkLogLevel.Debug))
				{
					logger.Log(SdkLogLevel.Debug, messageFormat, exception, args);
				}
			}
		}

		public void DebugFormat(string messageFormat, params object[] args)
		{
			foreach (IAdaptorLogger logger in _loggers)
			{
				if (logger.IsEnabled(SdkLogLevel.Debug))
				{
					logger.Log(SdkLogLevel.Debug, messageFormat, null, args);
				}
			}
		}

		public void InfoFormat(string messageFormat, params object[] args)
		{
			foreach (IAdaptorLogger logger in _loggers)
			{
				if (logger.IsEnabled(SdkLogLevel.Info))
				{
					logger.Log(SdkLogLevel.Info, messageFormat, null, args);
				}
			}
		}
	}
}
