using System;
using System.Collections.Generic;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer.Events
{
	public class RequestLobbyListResultEventArgs : EventArgs
	{
		public IReadOnlyList<ulong> LobbyIds { get; }

		public bool Success { get; }

		public RequestLobbyListResultEventArgs(List<ulong> lobbyIds, bool success)
		{
			LobbyIds = lobbyIds;
			Success = success;
		}
	}
}
