using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct JwtLoginRequest
	{
		[JsonProperty("token")]
		public string Token;

		[JsonProperty("autosignup")]
		public bool AutoSignup;
	}
}
