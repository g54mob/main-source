using System;
using System.Text;

namespace IngameDebugConsole
{
	public struct DebugLogEntryTimestamp
	{
		public readonly DateTime dateTime;

		public readonly float elapsedSeconds;

		public readonly int frameCount;

		public DebugLogEntryTimestamp(TimeSpan localTimeUtcOffset)
		{
			dateTime = default(DateTime);
			elapsedSeconds = 0f;
			frameCount = 0;
		}

		public void AppendTime(StringBuilder sb)
		{
		}

		public void AppendFullTimestamp(StringBuilder sb)
		{
		}
	}
}
