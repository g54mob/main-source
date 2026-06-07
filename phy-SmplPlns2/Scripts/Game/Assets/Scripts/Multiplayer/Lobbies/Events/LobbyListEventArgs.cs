using System;
using System.Collections.Generic;

namespace Assets.Scripts.Multiplayer.Lobbies.Events
{
	public class LobbyListEventArgs : EventArgs
	{
		public IReadOnlyList<LobbyData> Lobbies { get; }

		public bool Success { get; }

		public LobbyListEventArgs(IReadOnlyList<LobbyData> lobbies, bool success)
		{
			Lobbies = lobbies;
			Success = success;
		}
	}
}
