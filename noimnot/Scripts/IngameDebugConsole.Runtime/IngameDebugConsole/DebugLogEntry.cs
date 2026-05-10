using UnityEngine;

namespace IngameDebugConsole
{
	public class DebugLogEntry
	{
		private const int HASH_NOT_CALCULATED = -623218;

		public string logString;

		public string stackTrace;

		private string completeLog;

		public LogType logType;

		public int count;

		public int collapsedIndex;

		private int hashValue;

		public void Initialize(string logString, string stackTrace)
		{
		}

		public void Clear()
		{
		}

		public bool MatchesSearchTerm(string searchTerm)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public int GetContentHashCode()
		{
			return 0;
		}
	}
}
