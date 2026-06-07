using System;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer.Events
{
	public class LobbyDataUpdateEventArgs : EventArgs
	{
		public ulong LobbyId { get; }

		public bool Success { get; }

		public LobbyDataUpdateEventArgs(ulong lobbyId, bool success)
		{
			LobbyId = lobbyId;
			Success = success;
		}
	}
}
