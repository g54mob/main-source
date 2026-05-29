using Newtonsoft.Json;

namespace Edgegap.Editor.Api.Models
{
	public class AppPortsData
	{
		[JsonProperty("port")]
		public int Port { get; set; }

		[JsonProperty("protocol")]
		public string ProtocolStr { get; set; }

		[JsonProperty("to_check")]
		public bool ToCheck { get; set; }

		[JsonProperty("tls_upgrade")]
		public bool TlsUpgrade { get; set; }

		[JsonProperty("name")]
		public string PortName { get; set; }
	}
}
