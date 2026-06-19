using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyServerPostUpdateAsServerCompletedStateChange : PFLobbyStateChange
	{
		public int result { get; private set; }

		public PFLobbyHandle lobby { get; private set; }

		public object asyncContext { get; private set; }

		internal unsafe PFLobbyServerPostUpdateAsServerCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyServerPostUpdateAsServerCompletedStateChange serverPostUpdateAsServerCompleted = ref stateChangeUnion.serverPostUpdateAsServerCompleted;
			result = serverPostUpdateAsServerCompleted.result;
			lobby = new PFLobbyHandle(serverPostUpdateAsServerCompleted.lobby);
			if (serverPostUpdateAsServerCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(serverPostUpdateAsServerCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
		}
	}
}
