using System;
using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	[Serializable]
	public struct AnchorInfo
	{
		[JsonProperty("uid")]
		public long uid;

		[JsonProperty("uname")]
		public string userName;

		[JsonProperty("uface")]
		public string userFace;
	}
}
