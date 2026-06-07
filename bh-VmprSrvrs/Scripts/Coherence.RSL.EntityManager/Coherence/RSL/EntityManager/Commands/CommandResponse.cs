using Coherence.Entities;
using Coherence.ProtocolDef;

namespace Coherence.RSL.EntityManager.Commands
{
	public struct CommandResponse
	{
		public IEntityMessage Query;

		public CommandStatus Status;

		public uint Recipient;

		public static CommandResponse NewErrorCommandResponse(uint participant, uint sender, Entity errorEntity, CommandStatus status)
		{
			return default(CommandResponse);
		}
	}
}
