using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyClaimServerLobbyCompletedStateChange : PFLobbyStateChange
	{
		public int result { get; private set; }

		public object asyncContext { get; private set; }

		public string lobbyId { get; private set; }

		public PFLobbyHandle lobby { get; private set; }

		internal unsafe PFLobbyClaimServerLobbyCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyClaimServerLobbyCompletedStateChange claimServerLobbyCompleted = ref stateChangeUnion.claimServerLobbyCompleted;
			result = claimServerLobbyCompleted.result;
			lobby = new PFLobbyHandle(claimServerLobbyCompleted.lobby);
			lobbyId = Converters.PtrToStringUTF8(claimServerLobbyCompleted.lobbyId);
			if (claimServerLobbyCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(claimServerLobbyCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
		}
	}
}
