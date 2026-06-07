using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct MessagesReceived
	{
		[JsonProperty("lobby_id")]
		public string LobbyId;

		[JsonProperty("player_id")]
		public string PlayerSenderId;

		[JsonProperty("time")]
		public int Time;

		[JsonProperty("messages")]
		public List<string> Messages;
	}
}
