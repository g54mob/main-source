using System;
using System.IO;

namespace MLAPI.Serialization.Pooled
{
	public sealed class PooledBitWriter : BitWriter, IDisposable
	{
		private bool isDisposed;

		internal PooledBitWriter(Stream stream)
			: base(stream)
		{
		}

		public static PooledBitWriter Get(Stream stream)
		{
			PooledBitWriter writer = BitWriterPool.GetWriter(stream);
			writer.isDisposed = false;
			return writer;
		}

		public void Dispose()
		{
			if (!isDisposed)
			{
				isDisposed = true;
				BitWriterPool.PutBackInPool(this);
			}
		}
	}
}
