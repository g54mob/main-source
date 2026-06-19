using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyAddMemberCompletedStateChange : PFLobbyStateChange
	{
		public int result { get; private set; }

		public PFLobbyHandle lobby { get; private set; }

		public PFEntityKey localUser { get; private set; }

		public object asyncContext { get; private set; }

		internal unsafe PFLobbyAddMemberCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyAddMemberCompletedStateChange addMemberCompleted = ref stateChangeUnion.addMemberCompleted;
			result = addMemberCompleted.result;
			lobby = new PFLobbyHandle(addMemberCompleted.lobby);
			PlayFab.Multiplayer.Interop.PFEntityKey pFEntityKey = addMemberCompleted.localUser;
			localUser = new PFEntityKey(&pFEntityKey);
			asyncContext = null;
			if (addMemberCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(addMemberCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
		}
	}
}
