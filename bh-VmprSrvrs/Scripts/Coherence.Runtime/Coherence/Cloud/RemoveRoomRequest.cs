using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct RemoveRoomRequest
	{
		[JsonProperty("RoomID")]
		public ushort RoomId;
	}
}
