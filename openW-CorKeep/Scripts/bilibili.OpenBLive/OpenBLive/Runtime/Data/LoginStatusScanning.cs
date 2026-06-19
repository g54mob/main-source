using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	public struct LoginStatusScanning
	{
		[JsonProperty("status")]
		public bool status;

		[JsonProperty("data")]
		public int data;

		[JsonProperty("message")]
		public string message;
	}
}
