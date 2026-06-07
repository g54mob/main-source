using Coherence.Entities;
using Coherence.ProtocolDef;

namespace Coherence.RSL.EntityManager.Commands
{
	public struct AuthorityRequestRejectionMessage : IClientMessage
	{
		public uint Participant;

		public Entity Entity;

		public IEntityCommand Command;

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
