using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct RoomFetchResponse
	{
		[JsonProperty("rooms")]
		public RoomData[] Rooms;
	}
}
