using System;
using System.IO;

namespace Sentry.Infrastructure
{
	public class FileDiagnosticLogger : DiagnosticLogger
	{
		private readonly bool _alsoWriteToConsole;

		private readonly StreamWriter _writer;

		public FileDiagnosticLogger(string path, bool alsoWriteToConsole = false)
			: this(path, SentryLevel.Debug, alsoWriteToConsole)
		{
		}

		public FileDiagnosticLogger(string path, SentryLevel minimalLevel, bool alsoWriteToConsole = false)
			: base(minimalLevel)
		{
			FileStream stream = File.OpenWrite(path);
			_writer = new StreamWriter(stream);
			_alsoWriteToConsole = alsoWriteToConsole;
			AppDomain.CurrentDomain.ProcessExit += delegate
			{
				_writer.Flush();
				_writer.Dispose();
			};
		}

		protected override void LogMessage(string message)
		{
			_writer.WriteLine(message);
			if (_alsoWriteToConsole)
			{
				Console.WriteLine(message);
			}
		}
	}
}
