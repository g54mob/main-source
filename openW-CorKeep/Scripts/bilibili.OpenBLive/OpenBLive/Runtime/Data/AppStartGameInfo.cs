using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	public class AppStartGameInfo
	{
		[JsonProperty("game_id")]
		public string GameId;
	}
}
