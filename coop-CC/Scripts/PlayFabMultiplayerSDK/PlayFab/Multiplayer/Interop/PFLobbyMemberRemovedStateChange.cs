namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyMemberRemovedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public unsafe PFLobby* lobby;

		public PFEntityKey member;

		public PFLobbyMemberRemovedReason reason;
	}
}
