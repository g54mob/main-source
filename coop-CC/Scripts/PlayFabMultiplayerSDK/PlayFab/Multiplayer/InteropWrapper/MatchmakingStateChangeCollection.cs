using System.Collections.Generic;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public struct MatchmakingStateChangeCollection
	{
		public List<PFMatchmakingStateChange> StateChanges;

		public uint StateChangeCount;

		internal unsafe PlayFab.Multiplayer.Interop.PFMatchmakingStateChange** RawStateChanges;
	}
}
