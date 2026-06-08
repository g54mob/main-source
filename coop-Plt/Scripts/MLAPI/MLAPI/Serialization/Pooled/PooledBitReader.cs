using System;
using System.IO;

namespace MLAPI.Serialization.Pooled
{
	public sealed class PooledBitReader : BitReader, IDisposable
	{
		private bool isDisposed;

		internal PooledBitReader(Stream stream)
			: base(stream)
		{
		}

		public static PooledBitReader Get(Stream stream)
		{
			PooledBitReader reader = BitReaderPool.GetReader(stream);
			reader.isDisposed = false;
			return reader;
		}

		public void Dispose()
		{
			if (!isDisposed)
			{
				isDisposed = true;
				BitReaderPool.PutBackInPool(this);
			}
		}
	}
}
