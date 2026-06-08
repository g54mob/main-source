using System;

namespace MLAPI.Serialization.Pooled
{
	public sealed class PooledBitStream : BitStream, IDisposable
	{
		private bool isDisposed;

		internal PooledBitStream()
		{
		}

		public static PooledBitStream Get()
		{
			PooledBitStream stream = BitStreamPool.GetStream();
			stream.isDisposed = false;
			return stream;
		}

		public new void Dispose()
		{
			if (!isDisposed)
			{
				isDisposed = true;
				BitStreamPool.PutBackInPool(this);
			}
		}
	}
}
