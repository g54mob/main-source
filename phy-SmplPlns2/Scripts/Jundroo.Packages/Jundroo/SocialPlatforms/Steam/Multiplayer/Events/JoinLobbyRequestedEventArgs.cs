using System;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer.Events
{
	public class JoinLobbyRequestedEventArgs : EventArgs
	{
		public ulong FriendId { get; }

		public ulong LobbyId { get; }

		public JoinLobbyRequestedEventArgs(ulong lobbyId, ulong friendId)
		{
			LobbyId = lobbyId;
			FriendId = friendId;
		}
	}
}
