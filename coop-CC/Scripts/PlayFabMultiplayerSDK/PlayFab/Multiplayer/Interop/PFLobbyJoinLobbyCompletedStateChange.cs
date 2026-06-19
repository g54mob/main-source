namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyJoinLobbyCompletedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public int result;

		public PFEntityKey newMember;

		public unsafe void* asyncContext;

		public unsafe PFLobby* lobby;
	}
}
