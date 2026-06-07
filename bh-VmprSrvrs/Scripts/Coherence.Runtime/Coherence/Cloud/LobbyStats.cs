using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct LobbyStats
	{
		[JsonProperty("players")]
		public LobbyPlayerStats PlayersStats;
	}
}
