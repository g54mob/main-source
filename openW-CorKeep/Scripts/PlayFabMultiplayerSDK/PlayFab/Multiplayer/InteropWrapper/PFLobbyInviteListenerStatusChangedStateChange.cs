using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyInviteListenerStatusChangedStateChange : PFLobbyStateChange
	{
		public PFEntityKey listeningEntity { get; private set; }

		internal unsafe PFLobbyInviteListenerStatusChangedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			PlayFab.Multiplayer.Interop.PFEntityKey pFEntityKey = stateChangeUnion.inviteListenerStatusChanged.listeningEntity;
			listeningEntity = new PFEntityKey(&pFEntityKey);
		}
	}
}
