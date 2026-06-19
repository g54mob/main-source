namespace PlayFab.Multiplayer.Interop
{
	public struct PFMultiplayerPort
	{
		public unsafe sbyte* name;

		public uint num;

		public PFMultiplayerProtocolType protocol;
	}
}
