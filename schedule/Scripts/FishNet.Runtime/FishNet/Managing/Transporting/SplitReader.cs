using System;
using FishNet.Serializing;

namespace FishNet.Managing.Transporting
{
	internal class SplitReader
	{
		private long _tick;

		private int _expectedMessages;

		private ushort _receivedMessages;

		private PooledWriter _writer;

		internal SplitReader()
		{
		}

		internal void GetHeader(PooledReader reader, out int expectedMessages)
		{
			expectedMessages = default(int);
		}

		internal void Write(uint tick, PooledReader reader, int expectedMessages)
		{
		}

		internal ArraySegment<byte> GetFullMessage()
		{
			return default(ArraySegment<byte>);
		}

		private void Reset(uint tick = 0u, int expectedMessages = 0)
		{
		}
	}
}
