namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyClaimServerLobbyCompletedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public int result;

		public unsafe void* asyncContext;

		public unsafe sbyte* lobbyId;

		public unsafe PFLobby* lobby;
	}
}
