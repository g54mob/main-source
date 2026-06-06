using System;
using Steamworks;

namespace OffroadExplorer.Lobby
{
	[Serializable]
	public class LobbyPlayerInfo
	{
		public CSteamID steamId;

		public string playerName;

		public bool isReady;
	}
}
