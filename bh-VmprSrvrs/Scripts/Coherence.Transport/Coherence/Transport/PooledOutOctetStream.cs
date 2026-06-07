using Coherence.Brook.Octet;
using Coherence.Common.Pooling;

namespace Coherence.Transport
{
	internal class PooledOutOctetStream : OutOctetStream, IPoolable
	{
		private readonly IPool<PooledOutOctetStream> streamPool;

		public PooledOutOctetStream(IPool<PooledOutOctetStream> streamPool, int streamCapacity)
			: base(0)
		{
		}

		public void Return()
		{
		}

		public new void ResizeAndReset(int capacity)
		{
		}
	}
}
