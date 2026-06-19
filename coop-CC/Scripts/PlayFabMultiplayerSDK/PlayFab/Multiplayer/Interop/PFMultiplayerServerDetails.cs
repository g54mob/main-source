namespace PlayFab.Multiplayer.Interop
{
	public struct PFMultiplayerServerDetails
	{
		public unsafe sbyte* fqdn;

		public unsafe sbyte* ipv4Address;

		public unsafe PFMultiplayerPort* ports;

		public uint portCount;

		public unsafe sbyte* region;
	}
}
