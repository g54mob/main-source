using System.Collections.Generic;
using Coherence.Entities;

namespace Coherence
{
	public struct PacketSentDebugInfo
	{
		public Dictionary<ChannelID, Dictionary<Entity, OutgoingEntityUpdate>> ChangesSentPerChannel;

		public int TotalChanges;

		public uint OctetCount;
	}
}
