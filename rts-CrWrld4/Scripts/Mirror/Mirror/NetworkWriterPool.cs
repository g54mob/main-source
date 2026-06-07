namespace Mirror
{
	public static class NetworkWriterPool
	{
		private static readonly Pool<PooledNetworkWriter> Pool;

		public static PooledNetworkWriter GetWriter()
		{
			return null;
		}

		public static void Recycle(PooledNetworkWriter writer)
		{
		}
	}
}
