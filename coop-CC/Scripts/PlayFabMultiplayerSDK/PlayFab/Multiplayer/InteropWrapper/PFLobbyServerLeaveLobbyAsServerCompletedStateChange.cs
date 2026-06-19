using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyServerLeaveLobbyAsServerCompletedStateChange : PFLobbyStateChange
	{
		public PFLobbyHandle lobby { get; private set; }

		public object asyncContext { get; private set; }

		internal unsafe PFLobbyServerLeaveLobbyAsServerCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyServerLeaveLobbyAsServerCompletedStateChange serverLeaveLobbyAsServerCompleted = ref stateChangeUnion.serverLeaveLobbyAsServerCompleted;
			lobby = new PFLobbyHandle(serverLeaveLobbyAsServerCompleted.lobby);
			if (serverLeaveLobbyAsServerCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(serverLeaveLobbyAsServerCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
		}
	}
}
