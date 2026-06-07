using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct PlayerAttributesChangedPayload
	{
		[JsonProperty("lobby_id")]
		public string LobbyId;

		[JsonProperty("player_id")]
		public string PlayerId;

		[JsonProperty("attributes")]
		public List<CloudAttribute> AttributesChanged;
	}
}
