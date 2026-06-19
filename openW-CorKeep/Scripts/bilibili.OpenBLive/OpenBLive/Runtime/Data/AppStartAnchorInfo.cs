using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	public class AppStartAnchorInfo
	{
		[JsonProperty("room_id")]
		public long RoomId;

		[JsonProperty("uname")]
		public string UName;

		[JsonProperty("uface")]
		public string UFace;

		[JsonProperty("uid")]
		public string Uid;

		[JsonProperty("open_id")]
		public string OpenId;
	}
}
