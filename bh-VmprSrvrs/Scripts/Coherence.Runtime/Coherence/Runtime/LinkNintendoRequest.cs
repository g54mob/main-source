using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct LinkNintendoRequest : IPlayerAccountOperationRequest
	{
		[JsonProperty("token")]
		public string Token;

		[JsonProperty("force")]
		public bool Force;
	}
}
