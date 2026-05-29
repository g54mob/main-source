using System.Collections.Generic;
using System.Diagnostics;

namespace VisualDesignCafe.Nature
{
	internal class Logger : ILog
	{
		private readonly string _prefix;

		private int _indent;

		private Stack<Stopwatch> _timers;

		public long ElapsedMilliseconds => 0L;

		public bool Debug { get; set; }

		public Logger(string prefix)
		{
		}

		public void StartTimer()
		{
		}

		public long StopTimer()
		{
			return 0L;
		}

		public void Indent()
		{
		}

		public void Unindent()
		{
		}

		public void Log(string message)
		{
		}

		public void LogFormat(string message, params object[] args)
		{
		}

		public void LogWarning(string message)
		{
		}

		public void LogWarningFormat(string message, params object[] args)
		{
		}

		public void LogError(string message)
		{
		}

		public void LogErrorFormat(string message, params object[] args)
		{
		}

		private string GetIndent()
		{
			return null;
		}
	}
}
