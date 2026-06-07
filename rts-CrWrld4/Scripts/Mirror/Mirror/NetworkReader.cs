using System;

namespace Mirror
{
	public class NetworkReader
	{
		internal ArraySegment<byte> buffer;

		public int Position;

		public int Length => 0;

		public NetworkReader(byte[] bytes)
		{
		}

		public NetworkReader(ArraySegment<byte> segment)
		{
		}

		public byte ReadByte()
		{
			return 0;
		}

		public byte[] ReadBytes(byte[] bytes, int count)
		{
			return null;
		}

		public ArraySegment<byte> ReadBytesSegment(int count)
		{
			return default(ArraySegment<byte>);
		}

		public override string ToString()
		{
			return null;
		}

		public T Read<T>()
		{
			return default(T);
		}
	}
}
