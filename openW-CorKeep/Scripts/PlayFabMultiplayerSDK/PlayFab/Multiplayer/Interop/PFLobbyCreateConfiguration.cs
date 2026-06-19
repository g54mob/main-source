namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyCreateConfiguration
	{
		public uint maxMemberCount;

		public PFLobbyOwnerMigrationPolicy ownerMigrationPolicy;

		public PFLobbyAccessPolicy accessPolicy;

		public uint searchPropertyCount;

		public unsafe sbyte** searchPropertyKeys;

		public unsafe sbyte** searchPropertyValues;

		public uint lobbyPropertyCount;

		public unsafe sbyte** lobbyPropertyKeys;

		public unsafe sbyte** lobbyPropertyValues;
	}
}
