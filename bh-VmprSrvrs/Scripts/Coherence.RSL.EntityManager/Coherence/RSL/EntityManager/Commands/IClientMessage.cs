namespace Coherence.RSL.EntityManager.Commands
{
	public interface IClientMessage
	{
		uint GetParticipant();

		bool IsBroadcast();
	}
}
