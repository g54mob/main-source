using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyUpdatedStateChange : PFLobbyStateChange
	{
		public PFLobbyHandle lobby { get; private set; }

		public bool ownerUpdated { get; private set; }

		public bool maxMembersUpdated { get; private set; }

		public bool accessPolicyUpdated { get; private set; }

		public bool membershipLockUpdated { get; private set; }

		public string[] updatedSearchPropertyKeys { get; private set; }

		public string[] updatedLobbyPropertyKeys { get; private set; }

		public PFLobbyMemberUpdateSummary[] memberUpdates { get; private set; }

		public bool serverUpdated { get; private set; }

		public string[] updatedServerPropertyKeys { get; private set; }

		public bool serverConnectionStatusUpdated { get; private set; }

		internal unsafe PFLobbyUpdatedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyUpdatedStateChange lobbyUpdated = ref stateChangeUnion.lobbyUpdated;
			lobby = new PFLobbyHandle(lobbyUpdated.lobby);
			ownerUpdated = lobbyUpdated.ownerUpdated;
			maxMembersUpdated = lobbyUpdated.maxMembersUpdated;
			accessPolicyUpdated = lobbyUpdated.accessPolicyUpdated;
			membershipLockUpdated = lobbyUpdated.membershipLockUpdated;
			updatedSearchPropertyKeys = Converters.StringPtrToArray(lobbyUpdated.updatedSearchPropertyKeys, lobbyUpdated.updatedSearchPropertyCount);
			updatedLobbyPropertyKeys = Converters.StringPtrToArray(lobbyUpdated.updatedLobbyPropertyKeys, lobbyUpdated.updatedLobbyPropertyCount);
			memberUpdates = new PFLobbyMemberUpdateSummary[lobbyUpdated.memberUpdateCount];
			for (int i = 0; i < lobbyUpdated.memberUpdateCount; i++)
			{
				memberUpdates[i] = new PFLobbyMemberUpdateSummary(lobbyUpdated.memberUpdates[i]);
			}
			serverUpdated = lobbyUpdated.serverUpdated;
			updatedServerPropertyKeys = Converters.StringPtrToArray(lobbyUpdated.updatedServerPropertyKeys, lobbyUpdated.updatedServerPropertyCount);
			serverConnectionStatusUpdated = lobbyUpdated.serverConnectionStatusUpdated;
		}
	}
}
