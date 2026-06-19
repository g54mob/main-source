using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyServerPostUpdateCompletedStateChange : PFLobbyStateChange
	{
		public int result { get; private set; }

		public PFLobbyHandle lobby { get; private set; }

		public object asyncContext { get; private set; }

		internal unsafe PFLobbyServerPostUpdateCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyServerPostUpdateCompletedStateChange serverPostUpdateCompleted = ref stateChangeUnion.serverPostUpdateCompleted;
			result = serverPostUpdateCompleted.result;
			lobby = new PFLobbyHandle(serverPostUpdateCompleted.lobby);
			if (serverPostUpdateCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(serverPostUpdateCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
		}
	}
}
