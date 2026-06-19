using System;
using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	[Serializable]
	public struct Dm
	{
		[JsonProperty("uid")]
		public long uid;

		[JsonProperty("open_id")]
		public string openId;

		[JsonProperty("uname")]
		public string userName;

		[JsonProperty("uface")]
		public string userFace;

		[JsonProperty("timestamp")]
		public long timestamp;

		[JsonProperty("msg")]
		public string msg;

		[JsonProperty("fans_medal_level")]
		public long fansMedalLevel;

		[JsonProperty("fans_medal_name")]
		public string fansMedalName;

		[JsonProperty("fans_medal_wearing_status")]
		public bool fansMedalWearingStatus;

		[JsonProperty("guard_level")]
		public long guardLevel;

		[JsonProperty("room_id")]
		public long roomId;
	}
}
