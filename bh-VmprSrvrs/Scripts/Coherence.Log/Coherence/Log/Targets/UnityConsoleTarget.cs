using System;
using System.Text;
using System.Threading;
using UnityEngine;

namespace Coherence.Log.Targets
{
	public class UnityConsoleTarget : ILogTarget, IDisposable
	{
		private LogOption logOptions;

		private static readonly ThreadLocal<StringBuilder> StringBuilderCache;

		public LogLevel Level { get; set; }

		public bool LogStackTrace
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void Log(LogLevel level, string message, (string key, object value)[] args, Logger logger)
		{
		}

		public void Dispose()
		{
		}
	}
}
