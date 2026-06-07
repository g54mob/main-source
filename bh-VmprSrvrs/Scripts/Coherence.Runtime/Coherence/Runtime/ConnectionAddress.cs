using Newtonsoft.Json;

namespace Coherence.Runtime
{
	public struct ConnectionAddress
	{
		[JsonProperty("ip")]
		public string Ip;

		[JsonProperty("region")]
		public string Region;

		[JsonProperty("port")]
		public int Port;

		[JsonProperty("sig_port")]
		public int WebPort;

		[JsonProperty("sig_url")]
		public string SigURL;

		public override string ToString()
		{
			return null;
		}
	}
}
