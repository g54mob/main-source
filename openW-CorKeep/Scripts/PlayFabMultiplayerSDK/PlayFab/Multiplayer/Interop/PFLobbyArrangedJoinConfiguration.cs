namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyArrangedJoinConfiguration
	{
		public uint maxMemberCount;

		public PFLobbyOwnerMigrationPolicy ownerMigrationPolicy;

		public PFLobbyAccessPolicy accessPolicy;

		public uint memberPropertyCount;

		public unsafe sbyte** memberPropertyKeys;

		public unsafe sbyte** memberPropertyValues;
	}
}
