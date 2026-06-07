using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct LinkXboxRequest : IPlayerAccountOperationRequest
	{
		[JsonProperty("token")]
		public string Token;

		[JsonProperty("force")]
		public bool Force;
	}
}
