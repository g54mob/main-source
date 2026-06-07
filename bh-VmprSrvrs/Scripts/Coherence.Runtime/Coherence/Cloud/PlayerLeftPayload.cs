using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct PlayerLeftPayload
	{
		[JsonProperty("lobby_id")]
		public string LobbyId;

		[JsonProperty("player_id")]
		public string PlayerId;

		[JsonProperty("reason")]
		public string Reason;
	}
}
