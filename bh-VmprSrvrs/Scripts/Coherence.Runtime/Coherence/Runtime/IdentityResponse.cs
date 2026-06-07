using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct IdentityResponse
	{
		[JsonProperty("id")]
		public string Id;

		[JsonProperty("type")]
		public string Type;
	}
}
