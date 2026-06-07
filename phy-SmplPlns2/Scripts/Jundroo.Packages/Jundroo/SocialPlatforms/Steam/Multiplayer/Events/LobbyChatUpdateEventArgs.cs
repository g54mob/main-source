using System;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer.Events
{
	public class LobbyChatUpdateEventArgs : EventArgs
	{
		public ulong ChangedUserId { get; }

		public ulong LobbyId { get; }

		public ulong MakingChangeUserId { get; }

		public ChatMemberStateChangeType Type { get; }

		public LobbyChatUpdateEventArgs(ulong lobbyId, ulong changedUserId, ulong makingChangeUserId, ChatMemberStateChangeType type)
		{
			LobbyId = lobbyId;
			ChangedUserId = changedUserId;
			MakingChangeUserId = makingChangeUserId;
			Type = type;
		}
	}
}
