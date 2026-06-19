namespace PlayFab.Multiplayer.Interop
{
	public struct PFMatchmakingMatchMember
	{
		public PFEntityKey entityKey;

		public unsafe sbyte* teamId;

		public unsafe sbyte* attributes;
	}
}
