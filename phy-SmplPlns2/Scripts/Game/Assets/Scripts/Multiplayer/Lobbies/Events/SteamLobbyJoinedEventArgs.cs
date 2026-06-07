using System;

namespace Assets.Scripts.Multiplayer.Lobbies.Events
{
	public class SteamLobbyJoinedEventArgs : EventArgs
	{
		public bool AutoLoadScene { get; }

		public ulong LobbyId { get; }

		public ulong LobbyOwnerId { get; }

		public bool Success { get; }

		public SteamLobbyJoinedEventArgs(ulong lobbyId, ulong lobbyOwnerId, bool autoLoadScene, bool success)
		{
			LobbyId = lobbyId;
			LobbyOwnerId = lobbyOwnerId;
			AutoLoadScene = autoLoadScene;
			Success = success;
		}
	}
}
