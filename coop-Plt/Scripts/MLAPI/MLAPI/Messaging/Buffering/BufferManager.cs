using System;
using System.Collections.Generic;
using MLAPI.Serialization.Pooled;
using UnityEngine;

namespace MLAPI.Messaging.Buffering
{
	internal static class BufferManager
	{
		internal struct BufferedMessage
		{
			internal ulong sender;

			internal string channelName;

			internal PooledBitStream payload;

			internal float receiveTime;

			internal float bufferTime;
		}

		private static readonly Dictionary<ulong, Queue<BufferedMessage>> bufferQueues = new Dictionary<ulong, Queue<BufferedMessage>>();

		private static readonly List<ulong> _keysToDestroy = new List<ulong>();

		internal static Queue<BufferedMessage> ConsumeBuffersForNetworkId(ulong networkId)
		{
			if (bufferQueues.ContainsKey(networkId))
			{
				Queue<BufferedMessage> result = bufferQueues[networkId];
				bufferQueues.Remove(networkId);
				return result;
			}
			return null;
		}

		internal static void RecycleConsumedBufferedMessage(BufferedMessage message)
		{
			message.payload.Dispose();
		}

		internal static void BufferMessageForNetworkId(ulong networkId, ulong sender, string channelName, float receiveTime, ArraySegment<byte> payload)
		{
			if (!bufferQueues.ContainsKey(networkId))
			{
				bufferQueues.Add(networkId, new Queue<BufferedMessage>());
			}
			Queue<BufferedMessage> queue = bufferQueues[networkId];
			PooledBitStream pooledBitStream = PooledBitStream.Get();
			pooledBitStream.Write(payload.Array, payload.Offset, payload.Count);
			pooledBitStream.Position = 0L;
			queue.Enqueue(new BufferedMessage
			{
				bufferTime = Time.realtimeSinceStartup,
				channelName = channelName,
				payload = pooledBitStream,
				receiveTime = receiveTime,
				sender = sender
			});
		}

		internal static void CleanBuffer()
		{
			foreach (KeyValuePair<ulong, Queue<BufferedMessage>> bufferQueue in bufferQueues)
			{
				while (bufferQueue.Value.Count > 0 && Time.realtimeSinceStartup - bufferQueue.Value.Peek().bufferTime >= NetworkingManager.Singleton.NetworkConfig.MessageBufferTimeout)
				{
					BufferedMessage message = bufferQueue.Value.Dequeue();
					RecycleConsumedBufferedMessage(message);
				}
				if (bufferQueue.Value.Count == 0)
				{
					_keysToDestroy.Add(bufferQueue.Key);
				}
			}
			for (int i = 0; i < _keysToDestroy.Count; i++)
			{
				bufferQueues.Remove(_keysToDestroy[i]);
			}
			_keysToDestroy.Clear();
		}
	}
}
