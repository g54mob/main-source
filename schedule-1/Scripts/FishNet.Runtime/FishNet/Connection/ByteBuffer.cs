using System;

namespace FishNet.Connection
{
	internal class ByteBuffer
	{
		private int _reserve;

		internal int Remaining => 0;

		internal byte[] Data { get; private set; }

		internal int Length { get; private set; }

		internal int Size { get; private set; }

		internal bool HasData { get; private set; }

		internal ByteBuffer(int size, int reserve = 0)
		{
		}

		public void Dispose()
		{
		}

		internal void Reset()
		{
		}

		internal void CopySegment(uint tick, ArraySegment<byte> segment)
		{
		}

		internal void CopySegment(ArraySegment<byte> segment)
		{
		}
	}
}
