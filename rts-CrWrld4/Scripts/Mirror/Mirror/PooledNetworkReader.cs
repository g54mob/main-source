using System;

namespace Mirror
{
	public sealed class PooledNetworkReader : NetworkReader, IDisposable
	{
		internal PooledNetworkReader(byte[] bytes)
			: base(null)
		{
		}

		internal PooledNetworkReader(ArraySegment<byte> segment)
			: base(null)
		{
		}

		public void Dispose()
		{
		}
	}
}
