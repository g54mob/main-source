namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbySendInviteCompletedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public int result;

		public unsafe PFLobby* lobby;

		public PFEntityKey sender;

		public PFEntityKey invitee;

		public unsafe void* asyncContext;
	}
}
