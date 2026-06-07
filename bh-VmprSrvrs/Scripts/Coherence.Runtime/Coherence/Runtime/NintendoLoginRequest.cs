using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct NintendoLoginRequest
	{
		[JsonProperty("token")]
		public string Token;

		[JsonProperty("autosignup")]
		public bool AutoSignup;
	}
}
