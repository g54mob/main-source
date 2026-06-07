using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct RoomHostData
	{
		[JsonProperty("ip")]
		public string Ip;

		[JsonProperty("port")]
		public int Port;

		[JsonProperty("region")]
		public string Region;

		[JsonProperty("rs_version")]
		public string RSVersion;

		public override string ToString()
		{
			return null;
		}
	}
}
