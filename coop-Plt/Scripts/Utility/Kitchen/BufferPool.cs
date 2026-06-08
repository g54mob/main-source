using System.Collections.Generic;

namespace Kitchen
{
	public class BufferPool
	{
		public int Size;

		public Queue<byte[]> Pool = new Queue<byte[]>();

		public BufferPool(int size)
		{
			Size = size;
		}

		public byte[] Request(int min_size)
		{
			if (min_size > Size)
			{
				return new byte[min_size];
			}
			if (Pool.Count <= 0)
			{
				return new byte[Size];
			}
			return Pool.Dequeue();
		}

		public void Free(ref byte[] buffer)
		{
			if (buffer.Length == Size)
			{
				for (int i = 0; i < buffer.Length; i++)
				{
					buffer[i] = 0;
				}
				Pool.Enqueue(buffer);
			}
		}
	}
}
