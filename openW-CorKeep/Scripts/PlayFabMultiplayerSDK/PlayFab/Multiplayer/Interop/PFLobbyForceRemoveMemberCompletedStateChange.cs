namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyForceRemoveMemberCompletedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public int result;

		public unsafe PFLobby* lobby;

		public PFEntityKey targetMember;

		public unsafe void* asyncContext;
	}
}
