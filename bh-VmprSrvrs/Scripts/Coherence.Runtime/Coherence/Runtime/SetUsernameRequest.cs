using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct SetUsernameRequest : IPlayerAccountOperationRequest
	{
		[JsonProperty("username")]
		public string Username;

		[JsonProperty("password")]
		public string Password;

		[JsonProperty("force")]
		public bool Force;
	}
}
