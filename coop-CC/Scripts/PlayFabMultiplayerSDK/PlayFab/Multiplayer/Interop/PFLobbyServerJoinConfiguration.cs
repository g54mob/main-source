namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyServerJoinConfiguration
	{
		public uint serverPropertyCount;

		public unsafe sbyte** serverPropertyKeys;

		public unsafe sbyte** serverPropertyValues;
	}
}
