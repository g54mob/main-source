using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct PlayerJoinedPayload
	{
		[JsonProperty("lobby_id")]
		public string LobbyId;

		[JsonProperty("player")]
		public LobbyPlayer Player;
	}
}
