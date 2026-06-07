using Coherence.Connection;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct WorldData
	{
		[JsonProperty("id")]
		public ulong WorldId;

		[JsonProperty("name")]
		public string Name;

		[JsonProperty("host")]
		public HostData Host;

		[JsonProperty("tags")]
		public string[] Tags;

		[JsonProperty("region")]
		public string Region;

		public string AuthToken;

		public string RoomSecret;

		public override string ToString()
		{
			return null;
		}

		public static (EndpointData, bool, string) GetWorldEndpoint(WorldData world)
		{
			return default((EndpointData, bool, string));
		}

		public static WorldData GetLocalWorld(string ip)
		{
			return default(WorldData);
		}
	}
}
