namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyConnectToLobbyCompletedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public int result;

		public PFEntityKey newMember;

		public unsafe sbyte* lobbyId;

		public unsafe void* asyncContext;

		public unsafe PFLobby* lobby;
	}
}
