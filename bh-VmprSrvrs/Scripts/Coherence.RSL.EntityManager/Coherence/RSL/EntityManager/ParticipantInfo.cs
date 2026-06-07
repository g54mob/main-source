using Coherence.Connection;

namespace Coherence.RSL.EntityManager
{
	public struct ParticipantInfo
	{
		public uint Participant;

		public ConnectionType ConnectionType;

		public ClientID ClientID;

		public uint Scene;
	}
}
