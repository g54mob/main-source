using System;
using System.IO;

namespace Coherence.Log.Targets
{
	public class FileTarget : ILogTarget, IDisposable
	{
		private static readonly object threadlock;

		private bool disposed;

		private FileStream file;

		private StreamWriter writer;

		public LogLevel Level { get; set; }

		public FileTarget(string filePath)
		{
		}

		public void Log(LogLevel level, string message, (string key, object value)[] args, Logger logger)
		{
		}

		public void Dispose()
		{
		}
	}
}
