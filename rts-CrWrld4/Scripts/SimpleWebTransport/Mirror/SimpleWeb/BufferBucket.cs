using System.Collections.Concurrent;

namespace Mirror.SimpleWeb
{
	internal class BufferBucket : IBufferOwner
	{
		public readonly int arraySize;

		private readonly ConcurrentQueue<ArrayBuffer> buffers;

		internal int _current;

		public BufferBucket(int arraySize)
		{
		}

		public ArrayBuffer Take()
		{
			return null;
		}

		public void Return(ArrayBuffer buffer)
		{
		}

		private void IncrementCreated()
		{
		}

		private void DecrementCreated()
		{
		}
	}
}
