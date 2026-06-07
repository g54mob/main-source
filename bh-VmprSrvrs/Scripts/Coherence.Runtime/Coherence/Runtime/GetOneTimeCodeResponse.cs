using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct GetOneTimeCodeResponse : IPlayerAccountOperationResponse
	{
		[JsonProperty("code")]
		public string OneTimeCode;
	}
}
