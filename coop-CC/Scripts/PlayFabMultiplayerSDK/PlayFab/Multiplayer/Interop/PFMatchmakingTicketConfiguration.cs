namespace PlayFab.Multiplayer.Interop
{
	public struct PFMatchmakingTicketConfiguration
	{
		public uint timeoutInSeconds;

		public unsafe sbyte* queueName;

		public uint membersToMatchWithCount;

		public unsafe PFEntityKey* membersToMatchWith;
	}
}
