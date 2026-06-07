using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct LocalRoomData
	{
		[JsonProperty("RoomID")]
		public ushort RoomID;

		[JsonProperty("Secret")]
		public string Secret;
	}
}
