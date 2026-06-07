using System;

namespace FractureField
{
	public class LoggerOptions
	{
		public DateTime Timestamp { get; set; }

		public string TimestampFormat { get; set; }

		public LogCategory LogCategory { get; set; }

		public string Context { get; set; }
	}
}
