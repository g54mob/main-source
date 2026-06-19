namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyServerDeleteLobbyCompletedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public unsafe PFLobby* lobby;

		public unsafe void* asyncContext;
	}
}
