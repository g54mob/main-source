using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyDisconnectingStateChange : PFLobbyStateChange
	{
		public PFLobbyHandle lobby { get; private set; }

		public PFLobbyDisconnectingReason reason { get; private set; }

		internal unsafe PFLobbyDisconnectingStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyDisconnectingStateChange disconnecting = ref stateChangeUnion.disconnecting;
			lobby = new PFLobbyHandle(disconnecting.lobby);
			reason = (PFLobbyDisconnectingReason)disconnecting.reason;
		}
	}
}
