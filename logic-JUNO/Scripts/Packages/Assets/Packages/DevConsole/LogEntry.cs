using UnityEngine;

namespace Assets.Packages.DevConsole
{
	public class LogEntry
	{
		public LogType LogType { get; private set; }

		public string Message { get; private set; }

		public string MessageDetails { get; private set; }

		public LogEntry(string message, string messageDetails, LogType logType)
		{
			Message = message;
			MessageDetails = messageDetails ?? string.Empty;
			LogType = logType;
		}
	}
}
