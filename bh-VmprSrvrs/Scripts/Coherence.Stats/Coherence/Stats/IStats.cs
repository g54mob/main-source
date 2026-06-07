namespace Coherence.Stats
{
	public interface IStats
	{
		SimpleStats FetchSimpleInStats();

		SimpleStats FetchSimpleOutStats();

		void TrackIncomingMessages(MessageType messageType, int count = 1);

		void TrackOutgoingMessages(MessageType messageType, int count = 1);

		void TrackIncomingPacket(uint octetCount);

		void TrackOutgoingPacket(uint octetCount);

		void Flush(int stamp, double deltaTime);
	}
}
