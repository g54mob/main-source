using System;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer.Events
{
	public class CreateLobbyResultEventArgs : EventArgs
	{
		public ulong LobbyId { get; }

		public CreateLobbyResultType Result { get; }

		public CreateLobbyResultEventArgs(ulong lobbyId, CreateLobbyResultType result)
		{
			LobbyId = lobbyId;
			Result = result;
		}
	}
}
