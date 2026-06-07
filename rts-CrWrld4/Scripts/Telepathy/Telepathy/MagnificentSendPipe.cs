using System;
using System.Collections.Generic;

namespace Telepathy
{
	public class MagnificentSendPipe
	{
		private readonly Queue<ArraySegment<byte>> queue;

		private Pool<byte[]> pool;

		public int Count => 0;

		public int PoolCount => 0;

		public MagnificentSendPipe(int MaxMessageSize)
		{
		}

		public void Enqueue(ArraySegment<byte> message)
		{
		}

		public bool DequeueAndSerializeAll(ref byte[] payload, out int packetSize)
		{
			packetSize = default(int);
			return false;
		}

		public void Clear()
		{
		}
	}
}
