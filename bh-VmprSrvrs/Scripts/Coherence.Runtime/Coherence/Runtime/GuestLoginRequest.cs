using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct GuestLoginRequest
	{
		[JsonProperty("guest_id")]
		public string GuestId;

		[JsonProperty("autosignup")]
		public bool AutoSignup;
	}
}
