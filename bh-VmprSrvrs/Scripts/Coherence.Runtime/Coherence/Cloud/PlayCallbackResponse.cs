using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct PlayCallbackResponse
	{
		[JsonProperty("lobby_id")]
		public string LobbyId;

		[JsonProperty("room")]
		public RoomData Room;
	}
}
