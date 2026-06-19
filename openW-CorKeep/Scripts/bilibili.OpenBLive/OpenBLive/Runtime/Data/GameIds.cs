using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	public struct GameIds
	{
		[JsonProperty("game_ids")]
		public string[] gameIds;
	}
}
