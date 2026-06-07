using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct LobbyCreationRequest
	{
		[JsonProperty("tag")]
		public string Tag;

		[JsonProperty("name")]
		public string Name;

		[JsonProperty("max_players")]
		public int MaxPlayers;

		[JsonProperty("unlisted")]
		public bool Unlisted;

		[JsonProperty("secret")]
		public string Secret;

		[JsonProperty("region")]
		public string Region;

		[JsonProperty("sim_slug")]
		public string SimSlug;

		[JsonProperty("lobby_attr")]
		public List<CloudAttribute> LobbyAttributes;

		[JsonProperty("player_attr")]
		public List<CloudAttribute> PlayerAttributes;

		public static string GetRequestBody(CreateLobbyOptions options)
		{
			return null;
		}
	}
}
