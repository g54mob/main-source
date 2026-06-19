namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyAddMemberCompletedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public int result;

		public unsafe PFLobby* lobby;

		public PFEntityKey localUser;

		public unsafe void* asyncContext;
	}
}
