using System.Collections.Generic;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public struct LobbyStateChangeCollection
	{
		public List<PFLobbyStateChange> StateChanges;

		public uint StateChangeCount;

		internal unsafe PlayFab.Multiplayer.Interop.PFLobbyStateChange** RawStateChanges;
	}
}
