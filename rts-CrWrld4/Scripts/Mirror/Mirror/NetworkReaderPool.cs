using System;

namespace Mirror
{
	public static class NetworkReaderPool
	{
		private static readonly Pool<PooledNetworkReader> Pool;

		public static PooledNetworkReader GetReader(byte[] bytes)
		{
			return null;
		}

		public static PooledNetworkReader GetReader(ArraySegment<byte> segment)
		{
			return null;
		}

		public static void Recycle(PooledNetworkReader reader)
		{
		}
	}
}
