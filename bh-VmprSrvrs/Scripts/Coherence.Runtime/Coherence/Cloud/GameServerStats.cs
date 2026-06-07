using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct GameServerStats
	{
		[JsonProperty("connected_players")]
		public int ConnectedPlayers;
	}
}
