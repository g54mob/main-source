using System;
using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	[Serializable]
	public struct SuperChatDel
	{
		[JsonProperty("room_id")]
		public long roomId;

		[JsonProperty("message_ids")]
		public long[] messageIds;
	}
}
