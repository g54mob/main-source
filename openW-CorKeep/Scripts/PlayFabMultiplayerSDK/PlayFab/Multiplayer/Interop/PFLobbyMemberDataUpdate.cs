namespace PlayFab.Multiplayer.Interop
{
	public struct PFLobbyMemberDataUpdate
	{
		public uint memberPropertyCount;

		public unsafe sbyte** memberPropertyKeys;

		public unsafe sbyte** memberPropertyValues;
	}
}
