using System;

namespace Coherence.Stats
{
	public class SimpleStatsCollector
	{
		private SimpleStats currentStats;

		private readonly object lockObject;

		public void TrackPacket(int octetCount)
		{
		}

		public void TrackMessage(MessageType messageType, int count)
		{
		}

		public SimpleStats GetStatsAndClear(int stamp, TimeSpan duration)
		{
			return default(SimpleStats);
		}
	}
}
