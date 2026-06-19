using System;
using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	[Serializable]
	public struct Guard
	{
		[JsonProperty("guard_level")]
		public long guardLevel;

		[JsonProperty("guard_num")]
		public long guardNum;

		[JsonProperty("guard_unit")]
		public string guardUnit;

		[JsonProperty("fans_medal_level")]
		public long fansMedalLevel;

		[JsonProperty("fans_medal_name")]
		public string fansMedalName;

		[JsonProperty("fans_medal_wearing_status")]
		public bool fansMedalWearingStatus;

		[JsonProperty("user_info")]
		public UserInfo userInfo;

		[JsonProperty("room_id")]
		public long roomID;
	}
}
