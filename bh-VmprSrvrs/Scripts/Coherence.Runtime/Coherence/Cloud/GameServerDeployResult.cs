using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct GameServerDeployResult
	{
		[JsonProperty("id")]
		public ulong Id;

		[JsonProperty("secret")]
		public string Secret;
	}
}
