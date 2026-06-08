#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace Amazon.Runtime.Logging
{
	internal class DiagnosticAdaptorLogger : IAdaptorLogger
	{
		internal class DiagnosticLogMessage : ILogMessage
		{
			public object[] Args { get; private set; }

			public IFormatProvider Provider { get; private set; }

			public string Format { get; private set; }

			public DiagnosticLogMessage(string message)
				: this(CultureInfo.InvariantCulture, message)
			{
			}

			public DiagnosticLogMessage(string format, params object[] args)
				: this(CultureInfo.InvariantCulture, format, args)
			{
			}

			public DiagnosticLogMessage(IFormatProvider provider, string format, params object[] args)
			{
				Args = args;
				Format = format;
				Provider = provider;
			}

			public override string ToString()
			{
				return string.Format(Provider, Format, Args);
			}
		}

		private int eventId;

		private TraceSource _trace;

		public bool IsEnabled(SdkLogLevel level)
		{
			return _trace != null;
		}

		internal DiagnosticAdaptorLogger(TraceSource trace)
		{
			_trace = trace;
		}

		public void Log(SdkLogLevel level, string message, Exception ex, params object[] parameters)
		{
			int id = Interlocked.Increment(ref eventId);
			_trace.TraceData(ConvertLogLevel(level), id, new DiagnosticLogMessage(CultureInfo.InvariantCulture, message, parameters));
		}

		private TraceEventType ConvertLogLevel(SdkLogLevel level)
		{
			return level switch
			{
				SdkLogLevel.Trace => TraceEventType.Verbose, 
				SdkLogLevel.Debug => TraceEventType.Verbose, 
				SdkLogLevel.Info => TraceEventType.Information, 
				SdkLogLevel.Warn => TraceEventType.Warning, 
				SdkLogLevel.Error => TraceEventType.Error, 
				SdkLogLevel.Fatal => TraceEventType.Critical, 
				_ => TraceEventType.Information, 
			};
		}
	}
}
