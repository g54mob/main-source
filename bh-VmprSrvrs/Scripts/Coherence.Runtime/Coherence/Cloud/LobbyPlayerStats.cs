using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct LobbyPlayerStats
	{
		[JsonProperty("online")]
		public int PlayersOnline;

		[JsonProperty("in_lobbies")]
		public int PlayersInLobbies;

		[JsonProperty("in_rooms")]
		public int PlayersInRooms;

		[JsonProperty("regions")]
		public List<LobbyPlayersFilteredStats> Regions;

		[JsonProperty("tags")]
		public List<LobbyPlayersFilteredStats> Tags;
	}
}
