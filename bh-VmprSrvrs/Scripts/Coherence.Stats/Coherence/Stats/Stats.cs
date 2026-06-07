namespace Coherence.Stats
{
	public class Stats : IStats
	{
		private readonly SimpleStatsCollector simpleIn;

		private readonly SimpleStatsCollector simpleOut;

		private SimpleStats simpleInStats;

		private SimpleStats simpleOutStats;

		private int lastStamp;

		public SimpleStats FetchSimpleInStats()
		{
			return default(SimpleStats);
		}

		public SimpleStats FetchSimpleOutStats()
		{
			return default(SimpleStats);
		}

		public void TrackIncomingMessages(MessageType messageType, int count = 1)
		{
		}

		public void TrackOutgoingMessages(MessageType messageType, int count = 1)
		{
		}

		public void TrackIncomingPacket(uint octetCount)
		{
		}

		public void TrackOutgoingPacket(uint octetCount)
		{
		}

		public void Flush(int stamp, double deltaTime)
		{
		}
	}
}
