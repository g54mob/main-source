namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyMemberUpdateSummary
	{
		public PFEntityKey member;

		public bool connectionStatusUpdated;

		public uint updatedMemberPropertyCount;

		public unsafe sbyte** updatedMemberPropertyKeys;
	}
}
