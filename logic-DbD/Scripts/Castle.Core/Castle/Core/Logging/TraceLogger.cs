#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Castle.Core.Logging
{
	public class TraceLogger : LevelFilteredLogger
	{
		private static readonly Dictionary<string, TraceSource> cache = new Dictionary<string, TraceSource>();

		private TraceSource traceSource;

		public TraceLogger(string name)
			: base(name)
		{
			Initialize();
			base.Level = MapLoggerLevel(traceSource.Switch.Level);
		}

		public TraceLogger(string name, LoggerLevel level)
			: base(name, level)
		{
			Initialize();
			base.Level = MapLoggerLevel(traceSource.Switch.Level);
		}

		public override ILogger CreateChildLogger(string loggerName)
		{
			return InternalCreateChildLogger(loggerName);
		}

		private ILogger InternalCreateChildLogger(string loggerName)
		{
			return new TraceLogger(base.Name + "." + loggerName, base.Level);
		}

		protected override void Log(LoggerLevel loggerLevel, string loggerName, string message, Exception exception)
		{
			if (exception == null)
			{
				traceSource.TraceEvent(MapTraceEventType(loggerLevel), 0, message);
				return;
			}
			traceSource.TraceData(MapTraceEventType(loggerLevel), 0, message, exception);
		}

		private void Initialize()
		{
			lock (cache)
			{
				if (cache.TryGetValue(base.Name, out this.traceSource))
				{
					return;
				}
				SourceLevels defaultLevel = MapSourceLevels(base.Level);
				this.traceSource = new TraceSource(base.Name, defaultLevel);
				if (IsSourceConfigured(this.traceSource))
				{
					cache.Add(base.Name, this.traceSource);
					return;
				}
				TraceSource traceSource = new TraceSource("Default", defaultLevel);
				string value = ShortenName(base.Name);
				while (!string.IsNullOrEmpty(value))
				{
					TraceSource traceSource2 = new TraceSource(value, defaultLevel);
					if (IsSourceConfigured(traceSource2))
					{
						traceSource = traceSource2;
						break;
					}
					value = ShortenName(value);
				}
				this.traceSource.Switch = traceSource.Switch;
				this.traceSource.Listeners.Clear();
				foreach (TraceListener listener in traceSource.Listeners)
				{
					this.traceSource.Listeners.Add(listener);
				}
				cache.Add(base.Name, this.traceSource);
			}
		}

		private static string ShortenName(string name)
		{
			int num = name.LastIndexOf('.');
			if (num != -1)
			{
				return name.Substring(0, num);
			}
			return null;
		}

		private static bool IsSourceConfigured(TraceSource source)
		{
			if (source.Listeners.Count == 1 && source.Listeners[0] is DefaultTraceListener && source.Listeners[0].Name == "Default")
			{
				return false;
			}
			return true;
		}

		private static LoggerLevel MapLoggerLevel(SourceLevels level)
		{
			return level switch
			{
				SourceLevels.All => LoggerLevel.Trace, 
				SourceLevels.Verbose => LoggerLevel.Debug, 
				SourceLevels.Information => LoggerLevel.Info, 
				SourceLevels.Warning => LoggerLevel.Warn, 
				SourceLevels.Error => LoggerLevel.Error, 
				SourceLevels.Critical => LoggerLevel.Fatal, 
				_ => LoggerLevel.Off, 
			};
		}

		private static SourceLevels MapSourceLevels(LoggerLevel level)
		{
			return level switch
			{
				LoggerLevel.Trace => SourceLevels.All, 
				LoggerLevel.Debug => SourceLevels.Verbose, 
				LoggerLevel.Info => SourceLevels.Information, 
				LoggerLevel.Warn => SourceLevels.Warning, 
				LoggerLevel.Error => SourceLevels.Error, 
				LoggerLevel.Fatal => SourceLevels.Critical, 
				_ => SourceLevels.Off, 
			};
		}

		private static TraceEventType MapTraceEventType(LoggerLevel level)
		{
			switch (level)
			{
			case LoggerLevel.Debug:
			case LoggerLevel.Trace:
				return TraceEventType.Verbose;
			case LoggerLevel.Info:
				return TraceEventType.Information;
			case LoggerLevel.Warn:
				return TraceEventType.Warning;
			case LoggerLevel.Error:
				return TraceEventType.Error;
			case LoggerLevel.Fatal:
				return TraceEventType.Critical;
			default:
				return TraceEventType.Verbose;
			}
		}
	}
}
