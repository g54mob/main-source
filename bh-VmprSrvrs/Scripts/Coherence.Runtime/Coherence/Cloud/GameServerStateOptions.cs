using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct GameServerStateOptions
	{
		[JsonProperty("suspended")]
		public bool Suspended;

		[JsonProperty("secret")]
		public string Secret;
	}
}
