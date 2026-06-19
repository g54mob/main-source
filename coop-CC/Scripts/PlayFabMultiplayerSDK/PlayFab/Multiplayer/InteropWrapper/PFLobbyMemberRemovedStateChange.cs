using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyMemberRemovedStateChange : PFLobbyStateChange
	{
		public PFLobbyHandle lobby { get; private set; }

		public PFEntityKey member { get; private set; }

		public PFLobbyMemberRemovedReason reason { get; private set; }

		internal unsafe PFLobbyMemberRemovedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyMemberRemovedStateChange memberRemoved = ref stateChangeUnion.memberRemoved;
			lobby = new PFLobbyHandle(memberRemoved.lobby);
			PlayFab.Multiplayer.Interop.PFEntityKey pFEntityKey = memberRemoved.member;
			member = new PFEntityKey(&pFEntityKey);
			reason = (PFLobbyMemberRemovedReason)memberRemoved.reason;
		}
	}
}
