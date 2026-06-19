namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyServerDataUpdate
	{
		public unsafe PFEntityKey* newServer;

		public uint serverPropertyCount;

		public unsafe sbyte** serverPropertyKeys;

		public unsafe sbyte** serverPropertyValues;
	}
}
