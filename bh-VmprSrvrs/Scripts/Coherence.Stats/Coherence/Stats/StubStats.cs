namespace Coherence.Stats
{
	public class StubStats : IStats
	{
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
