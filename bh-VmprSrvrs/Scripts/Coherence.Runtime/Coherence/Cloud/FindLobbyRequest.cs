using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct FindLobbyRequest
	{
		[JsonProperty("tag")]
		public string Tag;

		[JsonProperty("max_players")]
		public int MaxPlayers;

		[JsonProperty("region")]
		public string Region;

		[JsonProperty("sim_slug")]
		public string SimSlug;

		[JsonProperty("filters")]
		public List<LobbyFilter> Filters;

		[JsonProperty("sort")]
		public List<LobbySortOption> Sort;

		[JsonProperty("lobby_attr")]
		public List<CloudAttribute> LobbyAttributes;

		[JsonProperty("player_attr")]
		public List<CloudAttribute> PlayerAttributes;

		public static string GetRequestBody(FindLobbyOptions findOptions, CreateLobbyOptions createOptions)
		{
			return null;
		}
	}
}
