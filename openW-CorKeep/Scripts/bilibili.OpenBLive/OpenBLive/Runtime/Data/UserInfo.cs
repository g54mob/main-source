using System;
using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	[Serializable]
	public struct UserInfo
	{
		[JsonProperty("uid")]
		public long uid;

		[JsonProperty("open_id")]
		public string openId;

		[JsonProperty("uname")]
		public string userName;

		[JsonProperty("uface")]
		public string userFace;
	}
}
