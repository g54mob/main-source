using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct LobbyData
	{
		[JsonProperty("id")]
		public string Id;

		[JsonProperty("name")]
		public string Name;

		[JsonProperty("region")]
		public string Region;

		[JsonProperty("tag")]
		public string Tag;

		[JsonProperty("max_players")]
		public int MaxPlayers;

		[JsonProperty("closed")]
		public bool Closed;

		[JsonProperty("unlisted")]
		public bool Unlisted;

		[JsonProperty("private")]
		public bool IsPrivate;

		[JsonProperty("owner_id")]
		internal string ownerId;

		[JsonProperty("sim_slug")]
		public string SimulatorSlug;

		[JsonProperty("room_id")]
		public long RoomId;

		[JsonProperty("room")]
		public RoomData? RoomData;

		[JsonProperty("players")]
		internal List<LobbyPlayer> players;

		[JsonProperty("attributes")]
		internal List<CloudAttribute> lobbyAttributes;

		public IReadOnlyList<CloudAttribute> Attributes => null;

		public IReadOnlyList<LobbyPlayer> Players => null;

		[JsonIgnore]
		public PlayerAccountId OwnerId => default(PlayerAccountId);

		public CloudAttribute? GetAttribute(string key)
		{
			return null;
		}
	}
}
