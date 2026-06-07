using UnityEngine;

namespace Mirror
{
	internal struct LogEntry
	{
		public string message;

		public LogType type;

		public LogEntry(string message, LogType type)
		{
			this.message = null;
			this.type = default(LogType);
		}
	}
}
