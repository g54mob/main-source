using System;
using Coherence.Brook.Octet;
using Coherence.Common.Pooling;

namespace Coherence.Transport
{
	public class PooledInOctetStream : InOctetStream, IPoolable
	{
		private readonly IPool<PooledInOctetStream> streamPool;

		public PooledInOctetStream(IPool<PooledInOctetStream> streamPool, int bufferSize = 0)
			: base(null)
		{
		}

		public void Return()
		{
		}

		public void Reset(ReadOnlySpan<byte> data)
		{
		}
	}
}
