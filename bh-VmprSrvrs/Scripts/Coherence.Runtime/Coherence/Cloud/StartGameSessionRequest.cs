using Newtonsoft.Json;

namespace Coherence.Cloud
{
	internal struct StartGameSessionRequest
	{
		[JsonProperty("max_players")]
		public int MaxPlayers;

		[JsonProperty("unlist_lobby")]
		public bool UnlistLobby;

		[JsonProperty("close_lobby")]
		public bool CloseLobby;

		public static string GetRequestBody(int maxPlayers, bool unlistLobby, bool closeLobby)
		{
			return null;
		}
	}
}
