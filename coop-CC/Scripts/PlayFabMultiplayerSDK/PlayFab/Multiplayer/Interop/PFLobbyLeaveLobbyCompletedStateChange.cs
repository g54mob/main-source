namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyLeaveLobbyCompletedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public unsafe PFLobby* lobby;

		public unsafe PFEntityKey* localUser;

		public unsafe void* asyncContext;
	}
}
