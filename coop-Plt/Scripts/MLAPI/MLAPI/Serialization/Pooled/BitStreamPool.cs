using System;
using System.Collections.Generic;
using MLAPI.Logging;

namespace MLAPI.Serialization.Pooled
{
	public static class BitStreamPool
	{
		private static byte createdStreams = 0;

		private static readonly Queue<WeakReference> overflowStreams = new Queue<WeakReference>();

		private static readonly Queue<PooledBitStream> streams = new Queue<PooledBitStream>();

		public static PooledBitStream GetStream()
		{
			if (streams.Count == 0)
			{
				if (overflowStreams.Count > 0)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
					{
						NetworkLog.LogInfo("Retrieving PooledBitStream from overflow pool. Recent burst?");
					}
					object obj = null;
					while (overflowStreams.Count > 0 && (obj = overflowStreams.Dequeue().Target) == null)
					{
					}
					if (obj != null)
					{
						PooledBitStream pooledBitStream = (PooledBitStream)obj;
						pooledBitStream.SetLength(0L);
						pooledBitStream.Position = 0L;
						return pooledBitStream;
					}
				}
				if (createdStreams == 254)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("255 streams have been created. Did you forget to dispose?");
					}
				}
				else if (createdStreams < byte.MaxValue)
				{
					createdStreams++;
				}
				return new PooledBitStream();
			}
			PooledBitStream pooledBitStream2 = streams.Dequeue();
			pooledBitStream2.SetLength(0L);
			pooledBitStream2.Position = 0L;
			return pooledBitStream2;
		}

		public static void PutBackInPool(PooledBitStream stream)
		{
			if (streams.Count > 16)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
				{
					NetworkLog.LogInfo("Putting PooledBitStream into overflow pool. Did you forget to dispose?");
				}
				overflowStreams.Enqueue(new WeakReference(stream));
			}
			else
			{
				streams.Enqueue(stream);
			}
		}
	}
}
