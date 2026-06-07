using System;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer.Events
{
	public class LobbyChatMessageEventArgs : EventArgs
	{
		public ulong LobbyId { get; }

		public byte[] MessageData { get; }

		public ChatEntryType Type { get; }

		public ulong UserId { get; }

		public LobbyChatMessageEventArgs(ulong lobbyId, ulong userId, ChatEntryType type, byte[] messageData)
		{
			LobbyId = lobbyId;
			UserId = userId;
			Type = type;
			MessageData = messageData;
		}
	}
}
