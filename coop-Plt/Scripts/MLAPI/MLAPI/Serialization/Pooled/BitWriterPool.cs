using System.Collections.Generic;
using System.IO;
using MLAPI.Logging;

namespace MLAPI.Serialization.Pooled
{
	public static class BitWriterPool
	{
		private static byte createdWriters = 0;

		private static readonly Queue<PooledBitWriter> writers = new Queue<PooledBitWriter>();

		public static PooledBitWriter GetWriter(Stream stream)
		{
			if (writers.Count == 0)
			{
				if (createdWriters == 254)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("255 writers have been created. Did you forget to dispose?");
					}
				}
				else if (createdWriters < byte.MaxValue)
				{
					createdWriters++;
				}
				return new PooledBitWriter(stream);
			}
			PooledBitWriter pooledBitWriter = writers.Dequeue();
			pooledBitWriter.SetStream(stream);
			return pooledBitWriter;
		}

		public static void PutBackInPool(PooledBitWriter writer)
		{
			if (writers.Count < 64)
			{
				writers.Enqueue(writer);
			}
			else if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("BitWriterPool already has 64 queued. Throwing to GC. Did you forget to dispose?");
			}
		}
	}
}
