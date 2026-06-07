using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct PasswordLoginRequest
	{
		[JsonProperty("username")]
		public string Username;

		[JsonProperty("password")]
		public string Password;

		[JsonProperty("autosignup")]
		public bool Autosignup;
	}
}
