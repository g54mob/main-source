using Coherence.Common.Pooling;
using Coherence.Transport;

namespace Coherence.RSL.Brisk
{
	internal class OutStreamPool
	{
		private Pool<PooledOutOctetStream> pool;

		public int MTU { get; }

		public OutStreamPool(int mtu = 1280)
		{
		}

		public PooledOutOctetStream Rent()
		{
			return null;
		}

		public PooledOutOctetStream Rent(int mtu)
		{
			return null;
		}

		public void Return(PooledOutOctetStream stream)
		{
		}
	}
}
