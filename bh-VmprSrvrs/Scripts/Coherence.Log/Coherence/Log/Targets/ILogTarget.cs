using System;

namespace Coherence.Log.Targets
{
	public interface ILogTarget : IDisposable
	{
		LogLevel Level { get; set; }

		void Log(LogLevel level, string message, (string key, object value)[] args, Logger logger);
	}
}
