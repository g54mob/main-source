using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct LobbyPlayersFilteredStats
	{
		[JsonProperty("in_lobbies")]
		public int PlayersInLobbies;

		[JsonProperty("in_rooms")]
		public int PlayersInRooms;

		[JsonProperty("filter")]
		public string Filter;
	}
}
