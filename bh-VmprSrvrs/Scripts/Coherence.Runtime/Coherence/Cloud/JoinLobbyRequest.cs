using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct JoinLobbyRequest
	{
		[JsonProperty("secret")]
		public string Secret;

		[JsonProperty("attributes")]
		public List<CloudAttribute> PlayerAttributes;

		public static string GetRequestBody(List<CloudAttribute> playerAttr, string secret)
		{
			return null;
		}
	}
}
