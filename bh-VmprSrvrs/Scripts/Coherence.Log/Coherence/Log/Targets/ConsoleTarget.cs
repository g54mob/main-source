using System;

namespace Coherence.Log.Targets
{
	public class ConsoleTarget : ILogTarget, IDisposable
	{
		private static readonly object locker;

		public LogLevel Level { get; set; }

		public void Log(LogLevel level, string message, (string key, object value)[] args, Logger logger)
		{
		}

		public void Dispose()
		{
		}
	}
}
