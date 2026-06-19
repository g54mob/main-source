namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyMemberAddedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public unsafe PFLobby* lobby;

		public PFEntityKey member;
	}
}
