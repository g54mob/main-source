using System.Collections.Generic;

namespace Brewery.Bar.Brawl
{
	public class BrawlSessionSnapshot
	{
		public int SessionId;

		public int ParticipantCount;

		public int SpectatorCount;

		public Dictionary<ulong, ulong> AttackerMappings;

		public List<ParticipantInfo> Participants;
	}
}
