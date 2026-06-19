namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyJoinConfiguration
	{
		public uint memberPropertyCount;

		public unsafe sbyte** memberPropertyKeys;

		public unsafe sbyte** memberPropertyValues;
	}
}
