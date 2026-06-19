using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyLeaveCompletedStateChange : PFLobbyStateChange
	{
		public PFEntityKey localUser { get; private set; }

		public object asyncContext { get; private set; }

		public PFLobbyHandle lobby { get; private set; }

		internal unsafe PFLobbyLeaveCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PFLobbyLeaveLobbyCompletedStateChange leaveCompleted = ref stateChangeUnion.leaveCompleted;
			PlayFab.Multiplayer.Interop.PFEntityKey* interopStruct = leaveCompleted.localUser;
			localUser = new PFEntityKey(interopStruct);
			asyncContext = null;
			if (leaveCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(leaveCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
			lobby = new PFLobbyHandle(leaveCompleted.lobby);
		}
	}
}
