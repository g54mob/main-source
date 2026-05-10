namespace Mono.Net.Security
{
	internal class BufferOffsetSize2 : BufferOffsetSize
	{
		public readonly int InitialSize;

		public BufferOffsetSize2(int size)
			: base(null, 0, 0)
		{
		}

		public void Reset()
		{
		}

		public void MakeRoom(int size)
		{
		}

		public void AppendData(byte[] buffer, int offset, int size)
		{
		}
	}
}
