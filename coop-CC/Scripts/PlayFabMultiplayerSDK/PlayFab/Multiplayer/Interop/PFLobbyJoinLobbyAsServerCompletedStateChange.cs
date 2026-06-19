namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyJoinLobbyAsServerCompletedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public int result;

		public PFEntityKey newServer;

		public unsafe void* asyncContext;

		public unsafe PFLobby* lobby;
	}
}
