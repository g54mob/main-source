using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct XboxLoginRequest
	{
		[JsonProperty("token")]
		public string Token;

		[JsonProperty("autosignup")]
		public bool AutoSignup;
	}
}
