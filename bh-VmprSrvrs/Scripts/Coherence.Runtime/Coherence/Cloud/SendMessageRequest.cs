using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct SendMessageRequest
	{
		[JsonProperty("messages")]
		public List<string> Messages;

		[JsonProperty("targets")]
		public List<string> Targets;

		public static string GetRequestBody(List<string> messages, List<LobbyPlayer> players)
		{
			return null;
		}
	}
}
