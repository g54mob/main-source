using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct SteamLoginRequest
	{
		[JsonProperty("ticket")]
		public string Ticket;

		[JsonProperty("identity")]
		public string Identity;

		[JsonProperty("autosignup")]
		public bool AutoSignup;
	}
}
