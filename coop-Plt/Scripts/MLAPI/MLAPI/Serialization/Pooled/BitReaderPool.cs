using System.Collections.Generic;
using System.IO;
using MLAPI.Logging;

namespace MLAPI.Serialization.Pooled
{
	public static class BitReaderPool
	{
		private static byte createdReaders = 0;

		private static readonly Queue<PooledBitReader> readers = new Queue<PooledBitReader>();

		public static PooledBitReader GetReader(Stream stream)
		{
			if (readers.Count == 0)
			{
				if (createdReaders == 254)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("255 readers have been created. Did you forget to dispose?");
					}
				}
				else if (createdReaders < byte.MaxValue)
				{
					createdReaders++;
				}
				return new PooledBitReader(stream);
			}
			PooledBitReader pooledBitReader = readers.Dequeue();
			pooledBitReader.SetStream(stream);
			return pooledBitReader;
		}

		public static void PutBackInPool(PooledBitReader reader)
		{
			if (readers.Count < 64)
			{
				readers.Enqueue(reader);
			}
			else if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("BitReaderPool already has 64 queued. Throwing to GC. Did you forget to dispose?");
			}
		}
	}
}
