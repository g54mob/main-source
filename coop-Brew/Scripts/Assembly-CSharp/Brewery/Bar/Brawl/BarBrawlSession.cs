using System.Collections.Generic;
using Brewery.NPC.Simple;

namespace Brewery.Bar.Brawl
{
	public class BarBrawlSession
	{
		public int SessionId { get; private set; }

		public HashSet<NPCBrawlAgent> Participants { get; private set; }

		public HashSet<NPCBrawlAgent> Spectators { get; private set; }

		public float LastActivityTime { get; set; }

		public BarBrawlSession(int sessionId)
		{
		}
	}
}
