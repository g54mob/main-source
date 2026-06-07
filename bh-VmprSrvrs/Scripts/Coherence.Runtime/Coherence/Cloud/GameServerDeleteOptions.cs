using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct GameServerDeleteOptions
	{
		[JsonProperty("secret")]
		public string Secret;
	}
}
