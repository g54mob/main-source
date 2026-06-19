namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyDataUpdate
	{
		public unsafe PFEntityKey* newOwner;

		public unsafe uint* maxMemberCount;

		public unsafe PFLobbyAccessPolicy* accessPolicy;

		public unsafe PFLobbyMembershipLock* membershipLock;

		public uint searchPropertyCount;

		public unsafe sbyte** searchPropertyKeys;

		public unsafe sbyte** searchPropertyValues;

		public uint lobbyPropertyCount;

		public unsafe sbyte** lobbyPropertyKeys;

		public unsafe sbyte** lobbyPropertyValues;
	}
}
