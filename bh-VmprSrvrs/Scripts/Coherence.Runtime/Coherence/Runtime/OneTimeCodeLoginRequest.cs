using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct OneTimeCodeLoginRequest
	{
		[JsonProperty("code")]
		public string Code;
	}
}
