using System;
using System.Text;

namespace IngameDebugConsole
{
	public struct DebugLogEntryTimestamp
	{
		public readonly DateTime dateTime;

		public readonly float elapsedSeconds;

		public readonly int frameCount;

		public DebugLogEntryTimestamp(DateTime dateTime, float elapsedSeconds, int frameCount)
		{
			this.dateTime = default(DateTime);
			this.elapsedSeconds = 0f;
			this.frameCount = 0;
		}

		public void AppendTime(StringBuilder sb)
		{
		}

		public void AppendFullTimestamp(StringBuilder sb)
		{
		}
	}
}
