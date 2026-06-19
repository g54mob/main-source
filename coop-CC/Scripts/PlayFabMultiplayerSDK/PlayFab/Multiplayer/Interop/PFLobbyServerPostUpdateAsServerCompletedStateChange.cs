namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyServerPostUpdateAsServerCompletedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public int result;

		public unsafe PFLobby* lobby;

		public unsafe void* asyncContext;
	}
}
