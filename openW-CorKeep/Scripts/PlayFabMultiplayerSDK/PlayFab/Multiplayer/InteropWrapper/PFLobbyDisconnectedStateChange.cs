using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyDisconnectedStateChange : PFLobbyStateChange
	{
		public PFLobbyHandle lobby { get; private set; }

		internal unsafe PFLobbyDisconnectedStateChange(PFLobbyStateChangeUnion stateChange, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChange.stateChange.stateChangeType, StateChangeId)
		{
			lobby = new PFLobbyHandle(stateChange.disconnected.lobby);
		}
	}
}
