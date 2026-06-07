using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.RSL.ReplicationManager.InBuffer
{
	internal class MessageResolver
	{
		private readonly IEntityMapper mapper;

		private readonly Logger logger;

		public MessageResolver(IEntityMapper mapper, Logger logger)
		{
		}

		public bool IsMessageResolvable(IEntityMessage message)
		{
			return false;
		}

		public bool ShouldDropMessage(IEntityMessage message)
		{
			return false;
		}
	}
}
