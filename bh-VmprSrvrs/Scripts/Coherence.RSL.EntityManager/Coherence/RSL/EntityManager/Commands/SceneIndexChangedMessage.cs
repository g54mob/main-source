using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Commands
{
	public struct SceneIndexChangedMessage : IClientMessage
	{
		public uint Participant;

		public Entity Entity;

		public uint SceneIndex;

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
