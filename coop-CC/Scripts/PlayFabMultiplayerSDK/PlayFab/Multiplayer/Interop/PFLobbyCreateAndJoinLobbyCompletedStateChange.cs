namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyCreateAndJoinLobbyCompletedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public int result;

		public unsafe void* asyncContext;

		public unsafe PFLobby* lobby;
	}
}
