using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct LobbiesFetchResponse
	{
		[JsonProperty("lobbies")]
		public List<LobbyData> Lobbies;
	}
}
