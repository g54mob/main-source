using System;
using Steamworks;

namespace OffroadExplorer.Lobby
{
	[Serializable]
	public class LobbyListEntry
	{
		public CSteamID lobbyId;

		public string lobbyName;

		public string hostName;

		public int currentPlayers;

		public int maxPlayers;

		public string version;

		public bool isVersionCompatible;
	}
}
