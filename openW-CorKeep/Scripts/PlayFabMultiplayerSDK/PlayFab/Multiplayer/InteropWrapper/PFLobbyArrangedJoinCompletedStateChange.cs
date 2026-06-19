using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyArrangedJoinCompletedStateChange : PFLobbyStateChange
	{
		public int result { get; private set; }

		public PFEntityKey newMember { get; private set; }

		public object asyncContext { get; private set; }

		public PFLobbyHandle lobby { get; private set; }

		internal unsafe PFLobbyArrangedJoinCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PFLobbyJoinArrangedLobbyCompletedStateChange arrangedJoinCompleted = ref stateChangeUnion.arrangedJoinCompleted;
			result = arrangedJoinCompleted.result;
			PlayFab.Multiplayer.Interop.PFEntityKey pFEntityKey = arrangedJoinCompleted.newMember;
			newMember = new PFEntityKey(&pFEntityKey);
			if (arrangedJoinCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(arrangedJoinCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
			lobby = new PFLobbyHandle(arrangedJoinCompleted.lobby);
		}
	}
}
