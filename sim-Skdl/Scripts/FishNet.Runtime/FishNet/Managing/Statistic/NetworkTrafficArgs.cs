namespace FishNet.Managing.Statistic
{
	public struct NetworkTrafficArgs
	{
		public readonly ulong ToServerBytes;

		public readonly ulong FromServerBytes;

		public NetworkTrafficArgs(ulong toServerBytes, ulong fromServerBytes)
		{
			ToServerBytes = 0uL;
			FromServerBytes = 0uL;
		}
	}
}
