using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct LobbyAttributesChangedPayload
	{
		[JsonProperty("lobby_id")]
		public string LobbyId;

		[JsonProperty("attributes")]
		public List<CloudAttribute> AttributesChanged;
	}
}
