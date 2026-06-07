using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;

namespace BestHTTP.Logger
{
	public sealed class ThreadedLogger : ILogger, IDisposable
	{
		private ILogOutput _output;

		private StringBuilder sb;

		public TimeSpan ExitThreadAfterInactivity;

		private ConcurrentQueue<LogJob> jobs;

		private AutoResetEvent newJobEvent;

		private int threadCreated;

		private bool isDisposed;

		public Loglevels Level { get; set; }

		public ILogOutput Output
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Verbose(string division, string msg, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null)
		{
		}

		public void Information(string division, string msg, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null)
		{
		}

		public void Warning(string division, string msg, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null)
		{
		}

		public void Error(string division, string msg, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null)
		{
		}

		public void Exception(string division, string msg, Exception ex, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null)
		{
		}

		private void AddJob(Loglevels level, string div, string msg, Exception ex, LoggingContext context1, LoggingContext context2, LoggingContext context3)
		{
		}

		private void ThreadFunc()
		{
		}

		public void Dispose()
		{
		}
	}
}
