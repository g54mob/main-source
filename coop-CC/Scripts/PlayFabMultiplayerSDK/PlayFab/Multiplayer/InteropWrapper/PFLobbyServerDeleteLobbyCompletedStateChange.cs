using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyServerDeleteLobbyCompletedStateChange : PFLobbyStateChange
	{
		public PFLobbyHandle lobby { get; private set; }

		public object asyncContext { get; private set; }

		internal unsafe PFLobbyServerDeleteLobbyCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyServerDeleteLobbyCompletedStateChange serverDeleteLobbyCompleted = ref stateChangeUnion.serverDeleteLobbyCompleted;
			lobby = new PFLobbyHandle(serverDeleteLobbyCompleted.lobby);
			if (serverDeleteLobbyCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(serverDeleteLobbyCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
		}
	}
}
