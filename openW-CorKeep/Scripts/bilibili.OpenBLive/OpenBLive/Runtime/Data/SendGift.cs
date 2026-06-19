using System;
using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	[Serializable]
	public struct SendGift
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

		[JsonProperty("gift_id")]
		public long giftId;

		[JsonProperty("gift_name")]
		public string giftName;

		[JsonProperty("gift_num")]
		public long giftNum;

		[JsonProperty("price")]
		public long price;

		[JsonProperty("paid")]
		public bool paid;

		[JsonProperty("fans_medal_level")]
		public long fansMedalLevel;

		[JsonProperty("fans_medal_name")]
		public string fansMedalName;

		[JsonProperty("fans_medal_wearing_status")]
		public bool fansMedalWearingStatus;

		[JsonProperty("guard_level")]
		public long guardLevel;

		[JsonProperty("timestamp")]
		public long timestamp;

		[JsonProperty("anchor_info")]
		public AnchorInfo anchorInfo;
	}
}
