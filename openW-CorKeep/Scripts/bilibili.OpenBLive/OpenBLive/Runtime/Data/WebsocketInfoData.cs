using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	public struct WebsocketInfoData
	{
		[JsonProperty("ip")]
		public List<string> ip;

		[JsonProperty("host")]
		public List<string> host;

		[JsonProperty("auth_body")]
		public string authBody;

		[JsonProperty("tcp_port")]
		public List<int> tcpPort;

		[JsonProperty("ws_port")]
		public List<int> wsPort;

		[JsonProperty("wss_port")]
		public List<int> wssPort;
	}
}
