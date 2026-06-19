using System;
using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	[Serializable]
	public struct Like
	{
		[JsonProperty("uname")]
		public string uname;

		[JsonProperty("uid")]
		public long uid;

		[JsonProperty("open_id")]
		public string openId;

		[JsonProperty("uface")]
		public string uface;

		[JsonProperty("timestamp")]
		public long timestamp;

		[JsonProperty("room_id")]
		public long room_id;

		[JsonProperty("like_text")]
		public string like_text;

		[JsonProperty("like_count")]
		public long unamelike_count;

		[JsonProperty("fans_medal_wearing_status")]
		public bool fans_medal_wearing_status;

		[JsonProperty("fans_medal_name")]
		public string fans_medal_name;

		[JsonProperty("fans_medal_level")]
		public long fans_medal_level;
	}
}
