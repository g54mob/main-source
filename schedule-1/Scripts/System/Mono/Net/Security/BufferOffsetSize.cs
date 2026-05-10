namespace Mono.Net.Security
{
	internal class BufferOffsetSize
	{
		public byte[] Buffer;

		public int Offset;

		public int Size;

		public int TotalBytes;

		public bool Complete;

		public int EndOffset => 0;

		public int Remaining => 0;

		public BufferOffsetSize(byte[] buffer, int offset, int size)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
