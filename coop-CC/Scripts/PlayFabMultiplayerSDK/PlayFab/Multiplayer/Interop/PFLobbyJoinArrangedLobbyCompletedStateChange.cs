namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyJoinArrangedLobbyCompletedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public int result;

		public PFEntityKey newMember;

		public unsafe void* asyncContext;

		public unsafe PFLobby* lobby;
	}
}
