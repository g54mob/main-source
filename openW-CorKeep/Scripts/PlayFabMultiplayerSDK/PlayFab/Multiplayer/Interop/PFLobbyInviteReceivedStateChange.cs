namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyInviteReceivedStateChange
	{
		public PFLobbyStateChange __AnonymousBase_1;

		public PFEntityKey listeningEntity;

		public PFEntityKey invitingEntity;

		public unsafe sbyte* connectionString;
	}
}
