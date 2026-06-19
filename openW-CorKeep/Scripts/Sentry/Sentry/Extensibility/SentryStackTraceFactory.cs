using System;
using System.Diagnostics;
using Sentry.Internal;

namespace Sentry.Extensibility
{
	public sealed class SentryStackTraceFactory : ISentryStackTraceFactory
	{
		private readonly SentryOptions _options;

		public SentryStackTraceFactory(SentryOptions options)
		{
			_options = options;
		}

		public SentryStackTrace? Create(Exception? exception = null)
		{
			if (exception == null && !_options.AttachStacktrace)
			{
				_options.LogDebug("No Exception and AttachStacktrace is off. No stack trace will be collected.");
				return null;
			}
			bool flag = exception == null && _options.AttachStacktrace;
			_options.LogDebug("Creating SentryStackTrace. isCurrentStackTrace: {0}.", flag);
			StackTrace stackTrace = ((exception == null) ? new StackTrace(fNeedFileInfo: true) : new StackTrace(exception, fNeedFileInfo: true));
			DebugStackTrace debugStackTrace = DebugStackTrace.Create(_options, stackTrace, flag);
			_options.LogDebug("Created {0} with {1} frames.", "DebugStackTrace", debugStackTrace.Frames.Count);
			if (debugStackTrace.Frames.Count == 0)
			{
				return null;
			}
			return debugStackTrace;
		}
	}
}
