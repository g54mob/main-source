using System;

namespace UnityWebSocketSharp
{
	internal class Logger
	{
		private string _file;

		private LogLevel _level;

		private Action<LogData, string> _output;

		private object _sync;

		public string File
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LogLevel Level
		{
			get
			{
				return default(LogLevel);
			}
			set
			{
			}
		}

		public Action<LogData, string> Output
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Logger()
		{
		}

		public Logger(LogLevel level)
		{
		}

		public Logger(LogLevel level, string file, Action<LogData, string> output)
		{
		}

		private static void defaultOutput(LogData data, string path)
		{
		}

		private void output(string message, LogLevel level)
		{
		}

		private static void writeToFile(string value, string path)
		{
		}

		public void Debug(string message)
		{
		}

		public void Error(string message)
		{
		}

		public void Fatal(string message)
		{
		}

		public void Info(string message)
		{
		}

		public void Trace(string message)
		{
		}

		public void Warn(string message)
		{
		}
	}
}
