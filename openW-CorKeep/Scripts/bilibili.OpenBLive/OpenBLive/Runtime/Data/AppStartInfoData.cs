using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	public class AppStartInfoData
	{
		[JsonProperty("game_info")]
		public AppStartGameInfo GameInfo;

		[JsonProperty("websocket_info")]
		public AppStartWebsocketInfo WebsocketInfo;

		[JsonProperty("anchor_info")]
		public AppStartAnchorInfo AnchorInfo;
	}
}
