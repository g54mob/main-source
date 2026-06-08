using System;
using System.IO;
using System.Text;

namespace Castle.Core.Logging
{
	[Serializable]
	public class StreamLogger : LevelFilteredLogger, IDisposable
	{
		private StreamWriter writer;

		public StreamLogger(string name, Stream stream)
			: this(name, new StreamWriter(stream))
		{
		}

		public StreamLogger(string name, Stream stream, Encoding encoding)
			: this(name, new StreamWriter(stream, encoding))
		{
		}

		public StreamLogger(string name, Stream stream, Encoding encoding, int bufferSize)
			: this(name, new StreamWriter(stream, encoding, bufferSize))
		{
		}

		~StreamLogger()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && writer != null)
			{
				writer.Dispose();
				writer = null;
			}
		}

		protected StreamLogger(string name, StreamWriter writer)
			: base(name, LoggerLevel.Trace)
		{
			this.writer = writer;
			writer.AutoFlush = true;
		}

		protected override void Log(LoggerLevel loggerLevel, string loggerName, string message, Exception exception)
		{
			if (writer != null)
			{
				writer.WriteLine("[{0}] '{1}' {2}", loggerLevel, loggerName, message);
				if (exception != null)
				{
					writer.WriteLine("[{0}] '{1}' {2}: {3} {4}", loggerLevel, loggerName, exception.GetType().FullName, exception.Message, exception.StackTrace);
				}
			}
		}

		public override ILogger CreateChildLogger(string loggerName)
		{
			throw new NotSupportedException("A streamlogger does not support child loggers");
		}
	}
}
