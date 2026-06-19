using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyForceRemoveMemberCompletedStateChange : PFLobbyStateChange
	{
		public int result { get; private set; }

		public PFLobbyHandle lobby { get; private set; }

		public PFEntityKey targetMember { get; private set; }

		public object asyncContext { get; private set; }

		internal unsafe PFLobbyForceRemoveMemberCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyForceRemoveMemberCompletedStateChange forceRemoveMember = ref stateChangeUnion.forceRemoveMember;
			result = forceRemoveMember.result;
			lobby = new PFLobbyHandle(forceRemoveMember.lobby);
			PlayFab.Multiplayer.Interop.PFEntityKey pFEntityKey = forceRemoveMember.targetMember;
			targetMember = new PFEntityKey(&pFEntityKey);
			asyncContext = null;
			if (forceRemoveMember.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(forceRemoveMember.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
		}
	}
}
