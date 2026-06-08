namespace kcp2k
{
	public static class KcpHeader
	{
		public static bool ParseReliable(byte value, out KcpHeaderReliable header)
		{
			header = default(KcpHeaderReliable);
			return false;
		}

		public static bool ParseUnreliable(byte value, out KcpHeaderUnreliable header)
		{
			header = default(KcpHeaderUnreliable);
			return false;
		}
	}
}
