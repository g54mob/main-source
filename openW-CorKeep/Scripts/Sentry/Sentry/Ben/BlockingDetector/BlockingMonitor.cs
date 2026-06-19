using System;
using System.Diagnostics;
using System.Threading;
using Sentry.Internal;
using Sentry.Protocol;

namespace Sentry.Ben.BlockingDetector
{
	internal class BlockingMonitor : IBlockingMonitor
	{
		private readonly Func<IHub> _getHub;

		private readonly SentryOptions _options;

		internal readonly IRecursionTracker _recursionTracker;

		public BlockingMonitor(Func<IHub> getHub, SentryOptions options)
			: this(getHub, options, new StaticRecursionTracker())
		{
		}

		internal BlockingMonitor(Func<IHub> getHub, SentryOptions options, IRecursionTracker recursionTracker)
		{
			_getHub = getHub;
			_options = options;
			_recursionTracker = recursionTracker;
		}

		private static bool ShouldSkipFrame(string? frameInfo)
		{
			if ((frameInfo == null || !frameInfo.StartsWith("Sentry.Ben")) && (frameInfo == null || !frameInfo.StartsWith("System.Diagnostics")))
			{
				return frameInfo?.StartsWith("System.Threading") ?? false;
			}
			return true;
		}

		public void BlockingStart(DetectionSource detectionSource)
		{
			if (!Thread.CurrentThread.IsThreadPoolThread)
			{
				return;
			}
			_recursionTracker.Recurse();
			try
			{
				if (_recursionTracker.IsFirstRecursion())
				{
					DebugStackTrace stacktrace = DebugStackTrace.Create(_options, new StackTrace(fNeedFileInfo: true), isCurrentStackTrace: true, ShouldSkipFrame);
					SentryEvent sentryEvent = new SentryEvent();
					sentryEvent.Level = SentryLevel.Warning;
					sentryEvent.Message = "Blocking method has been invoked and blocked, this can lead to ThreadPool starvation. Learn more about it: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices#avoid-blocking-calls ";
					sentryEvent.SentryExceptions = new SentryException[1]
					{
						new SentryException
						{
							ThreadId = Environment.CurrentManagedThreadId,
							Mechanism = new Mechanism
							{
								Type = "BlockingCallDetector",
								Handled = false,
								Description = "Blocking calls can cause ThreadPool starvation.",
								Source = detectionSource.ToString()
							},
							Type = "Blocking call detected",
							Stacktrace = stacktrace
						}
					};
					SentryEvent evt = sentryEvent;
					_getHub().CaptureEvent(evt);
				}
			}
			catch
			{
			}
		}

		public void BlockingEnd()
		{
			if (Thread.CurrentThread.IsThreadPoolThread)
			{
				_recursionTracker.Backtrack();
			}
		}
	}
}
