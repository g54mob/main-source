using System.Collections.Generic;
using Coherence.Connection;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct RoomData
	{
		public const string RoomNameKey = "name";

		[JsonProperty("room_id")]
		public ushort Id;

		[JsonProperty("unique_id")]
		public ulong UniqueId;

		[JsonProperty("host")]
		public RoomHostData Host;

		[JsonProperty("max_players")]
		public int MaxPlayers;

		[JsonProperty("connected_players")]
		public int ConnectedPlayers;

		[JsonProperty("kv")]
		public Dictionary<string, string> KV;

		[JsonProperty("tags")]
		public string[] Tags;

		[JsonProperty("sim_slug")]
		public string SimSlug;

		[JsonProperty("secret")]
		public string Secret;

		[JsonProperty("created_at")]
		public string CreatedAt;

		public string AuthToken;

		private string roomName;

		public string RoomName => null;

		public static (EndpointData, bool, string) GetRoomEndpointData(RoomData room)
		{
			return default((EndpointData, bool, string));
		}

		public override string ToString()
		{
			return null;
		}

		private string ExtractRoomName()
		{
			return null;
		}
	}
}
