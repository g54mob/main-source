using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyJoinCompletedStateChange : PFLobbyStateChange
	{
		public int result { get; private set; }

		public PFEntityKey newMember { get; private set; }

		public object asyncContext { get; private set; }

		public PFLobbyHandle lobby { get; private set; }

		internal unsafe PFLobbyJoinCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PFLobbyJoinLobbyCompletedStateChange joinCompleted = ref stateChangeUnion.joinCompleted;
			result = joinCompleted.result;
			PlayFab.Multiplayer.Interop.PFEntityKey pFEntityKey = joinCompleted.newMember;
			newMember = new PFEntityKey(&pFEntityKey);
			asyncContext = null;
			if (joinCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(joinCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
			lobby = new PFLobbyHandle(joinCompleted.lobby);
		}
	}
}
