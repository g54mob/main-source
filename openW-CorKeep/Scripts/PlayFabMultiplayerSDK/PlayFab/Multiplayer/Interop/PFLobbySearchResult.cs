namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbySearchResult
	{
		public unsafe sbyte* lobbyId;

		public unsafe sbyte* connectionString;

		public unsafe PFEntityKey* ownerEntity;

		public uint maxMemberCount;

		public uint currentMemberCount;

		public uint searchPropertyCount;

		public unsafe sbyte** searchPropertyKeys;

		public unsafe sbyte** searchPropertyValues;

		public uint friendCount;

		public unsafe PFEntityKey* friends;

		public PFLobbyMembershipLock membershipLock;
	}
}
