using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Commands
{
	public struct AuthorityChangedMessage : IClientMessage
	{
		public uint Participant;

		public Entity Entity;

		public ICoherenceComponentData[] Data;

		public EntityMeta Meta;

		public uint Origin;

		public bool IsTransferToOtherClient;

		public uint GetParticipant()
		{
			return 0u;
		}

		public bool IsBroadcast()
		{
			return false;
		}
	}
}
