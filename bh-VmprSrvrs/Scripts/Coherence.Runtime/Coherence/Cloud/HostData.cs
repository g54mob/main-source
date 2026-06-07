using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct HostData
	{
		[JsonProperty("ip")]
		public string Ip;

		[JsonProperty("udp_port")]
		public int UDPPort;

		[JsonProperty("sig_url")]
		public string SigURL;

		[JsonProperty("sig_port")]
		public int SigPort;

		[JsonProperty("web_port")]
		public int WebPort;

		[JsonProperty("region")]
		public string Region;

		public override string ToString()
		{
			return null;
		}
	}
}
