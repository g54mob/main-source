using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyCreateAndClaimServerLobbyCompletedStateChange : PFLobbyStateChange
	{
		public int result { get; private set; }

		public PFLobbyHandle lobby { get; private set; }

		public object asyncContext { get; private set; }

		internal unsafe PFLobbyCreateAndClaimServerLobbyCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyCreateAndClaimServerLobbyCompletedStateChange createAndClaimServerLobbyCompleted = ref stateChangeUnion.createAndClaimServerLobbyCompleted;
			result = createAndClaimServerLobbyCompleted.result;
			lobby = new PFLobbyHandle(createAndClaimServerLobbyCompleted.lobby);
			if (createAndClaimServerLobbyCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(createAndClaimServerLobbyCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
		}
	}
}
