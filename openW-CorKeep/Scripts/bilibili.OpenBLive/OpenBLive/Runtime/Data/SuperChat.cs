using System;
using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	[Serializable]
	public struct SuperChat
	{
		[JsonProperty("room_id")]
		public long roomId;

		[JsonProperty("uid")]
		public long uid;

		[JsonProperty("open_id")]
		public string openId;

		[JsonProperty("uname")]
		public string userName;

		[JsonProperty("uface")]
		public string userFace;

		[JsonProperty("message_id")]
		public long messageId;

		[JsonProperty("message")]
		public string message;

		[JsonProperty("rmb")]
		public long rmb;

		[JsonProperty("timestamp")]
		public long timeStamp;

		[JsonProperty("start_time")]
		public long startTime;

		[JsonProperty("end_time")]
		public long endTime;

		[JsonProperty("guard_level")]
		public long guardLevel;

		[JsonProperty("fans_medal_level")]
		public long fansMedalLevel;

		[JsonProperty("fans_medal_name")]
		public string fansMedalName;

		[JsonProperty("fans_medal_wearing_status")]
		public bool fansMedalWearingStatus;
	}
}
