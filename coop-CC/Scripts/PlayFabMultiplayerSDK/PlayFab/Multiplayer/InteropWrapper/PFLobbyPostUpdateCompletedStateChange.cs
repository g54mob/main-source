using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyPostUpdateCompletedStateChange : PFLobbyStateChange
	{
		public int result;

		public PFLobbyHandle lobby;

		public PFEntityKey localUser;

		public object asyncContext;

		internal unsafe PFLobbyPostUpdateCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyPostUpdateCompletedStateChange postUpdateCompleted = ref stateChangeUnion.postUpdateCompleted;
			result = postUpdateCompleted.result;
			lobby = new PFLobbyHandle(postUpdateCompleted.lobby);
			PlayFab.Multiplayer.Interop.PFEntityKey pFEntityKey = postUpdateCompleted.localUser;
			localUser = new PFEntityKey(&pFEntityKey);
			asyncContext = null;
			if (postUpdateCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(postUpdateCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
		}
	}
}
