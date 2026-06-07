using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct EpicGamesLoginRequest
	{
		[JsonProperty("token")]
		public string Token;

		[JsonProperty("autosignup")]
		public bool AutoSignup;
	}
}
