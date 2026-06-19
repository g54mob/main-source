using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	public class AppStartWebsocketInfo
	{
		[JsonProperty("auth_body")]
		public string AuthBody;

		[JsonProperty("wss_link")]
		public List<string> WssLink;
	}
}
