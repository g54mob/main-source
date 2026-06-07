using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct OwnerChangedPayload
	{
		[JsonProperty("lobby_id")]
		public string LobbyId;

		[JsonProperty("player_id")]
		public string PlayerId;
	}
}
