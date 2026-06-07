using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct RoomMatchResponse
	{
		[JsonProperty("room")]
		public RoomData? Room;
	}
}
