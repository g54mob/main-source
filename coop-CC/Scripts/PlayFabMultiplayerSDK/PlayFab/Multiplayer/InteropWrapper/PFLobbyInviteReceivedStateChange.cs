using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyInviteReceivedStateChange : PFLobbyStateChange
	{
		public PFEntityKey listeningEntity { get; private set; }

		public PFEntityKey invitingEntity { get; private set; }

		public string connectionString { get; private set; }

		internal unsafe PFLobbyInviteReceivedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyInviteReceivedStateChange inviteReceivedStateChange = ref stateChangeUnion.inviteReceivedStateChange;
			PlayFab.Multiplayer.Interop.PFEntityKey pFEntityKey = inviteReceivedStateChange.listeningEntity;
			listeningEntity = new PFEntityKey(&pFEntityKey);
			PlayFab.Multiplayer.Interop.PFEntityKey pFEntityKey2 = inviteReceivedStateChange.invitingEntity;
			invitingEntity = new PFEntityKey(&pFEntityKey2);
			connectionString = Converters.PtrToStringUTF8(inviteReceivedStateChange.connectionString);
		}
	}
}
