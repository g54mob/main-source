using System;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer.Events
{
	public class LobbyMemberDataUpdateEventArgs : EventArgs
	{
		public ulong LobbyId { get; }

		public bool Success { get; }

		public ulong UserId { get; }

		public LobbyMemberDataUpdateEventArgs(ulong lobbyId, ulong userId, bool success)
		{
			LobbyId = lobbyId;
			UserId = userId;
			Success = success;
		}
	}
}
