using UnityEngine;

namespace IngameDebugConsole
{
	public struct QueuedDebugLogEntry
	{
		public readonly string logString;

		public readonly string stackTrace;

		public readonly LogType logType;

		public QueuedDebugLogEntry(string logString, string stackTrace, LogType logType)
		{
			this.logString = null;
			this.stackTrace = null;
			this.logType = default(LogType);
		}

		public bool MatchesSearchTerm(string searchTerm)
		{
			return false;
		}
	}
}
