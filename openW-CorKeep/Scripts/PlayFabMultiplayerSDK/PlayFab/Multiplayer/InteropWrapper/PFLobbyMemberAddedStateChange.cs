using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyMemberAddedStateChange : PFLobbyStateChange
	{
		public PFLobbyHandle lobby { get; private set; }

		public PFEntityKey member { get; private set; }

		internal unsafe PFLobbyMemberAddedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyMemberAddedStateChange memberAdded = ref stateChangeUnion.memberAdded;
			lobby = new PFLobbyHandle(memberAdded.lobby);
			PlayFab.Multiplayer.Interop.PFEntityKey pFEntityKey = memberAdded.member;
			member = new PFEntityKey(&pFEntityKey);
		}
	}
}
