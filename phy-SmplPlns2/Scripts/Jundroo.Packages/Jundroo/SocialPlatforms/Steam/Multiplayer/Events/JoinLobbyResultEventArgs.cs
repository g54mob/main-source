using System;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer.Events
{
	public class JoinLobbyResultEventArgs : EventArgs
	{
		public ulong LobbyId { get; }

		public bool Locked { get; }

		public JoinLobbyResultType Result { get; }

		public JoinLobbyResultEventArgs(ulong lobbyId, bool locked, JoinLobbyResultType result)
		{
			LobbyId = lobbyId;
			Locked = locked;
			Result = result;
		}
	}
}
