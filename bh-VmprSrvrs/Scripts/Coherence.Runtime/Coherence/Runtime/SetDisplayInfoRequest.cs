using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct SetDisplayInfoRequest : IPlayerAccountOperationRequest
	{
		[JsonProperty("display_name")]
		public string DisplayName;

		[JsonProperty("avatar_url")]
		public string AvatarUrl;
	}
}
