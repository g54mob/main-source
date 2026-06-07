using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct LocalRoomsResponse
	{
		[JsonProperty("Rooms")]
		public LocalRoomsListItem[] Rooms;
	}
}
