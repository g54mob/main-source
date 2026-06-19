using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyCreateAndJoinCompletedStateChange : PFLobbyStateChange
	{
		public int result { get; private set; }

		public object asyncContext { get; private set; }

		public PFLobbyHandle lobby { get; private set; }

		internal unsafe PFLobbyCreateAndJoinCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			PFLobbyCreateAndJoinLobbyCompletedStateChange createAndJoinCompleted = stateChangeUnion.createAndJoinCompleted;
			result = createAndJoinCompleted.result;
			asyncContext = null;
			if (createAndJoinCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(createAndJoinCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
			lobby = new PFLobbyHandle(createAndJoinCompleted.lobby);
		}
	}
}
