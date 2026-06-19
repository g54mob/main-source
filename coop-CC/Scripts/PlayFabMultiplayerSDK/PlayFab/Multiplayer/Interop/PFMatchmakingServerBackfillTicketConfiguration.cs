namespace PlayFab.Multiplayer.Interop
{
	public struct PFMatchmakingServerBackfillTicketConfiguration
	{
		public uint timeoutInSeconds;

		public unsafe sbyte* queueName;

		public uint memberCount;

		public unsafe PFMatchmakingMatchMember* members;

		public unsafe PFMultiplayerServerDetails* serverDetails;
	}
}
