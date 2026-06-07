using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct SetEmailRequest : IPlayerAccountOperationRequest
	{
		[JsonProperty("email")]
		public string Email;
	}
}
