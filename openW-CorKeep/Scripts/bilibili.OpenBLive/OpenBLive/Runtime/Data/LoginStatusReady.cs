using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	public struct LoginStatusReady
	{
		[JsonProperty("code")]
		public int code;

		[JsonProperty("status")]
		public bool status;

		[JsonProperty("data")]
		public LoginStatusData data;
	}
}
