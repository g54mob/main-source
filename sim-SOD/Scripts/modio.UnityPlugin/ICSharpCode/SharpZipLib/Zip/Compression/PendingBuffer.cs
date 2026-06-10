namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	public class PendingBuffer
	{
		private readonly byte[] buffer;

		private int start;

		private int end;

		private uint bits;

		private int bitCount;

		public int BitCount => 0;

		public bool IsFlushed => false;

		public PendingBuffer()
		{
		}

		public PendingBuffer(int bufferSize)
		{
		}

		public void Reset()
		{
		}

		public void WriteByte(int value)
		{
		}

		public void WriteShort(int value)
		{
		}

		public void WriteInt(int value)
		{
		}

		public void WriteBlock(byte[] block, int offset, int length)
		{
		}

		public void AlignToByte()
		{
		}

		public void WriteBits(int b, int count)
		{
		}

		public void WriteShortMSB(int s)
		{
		}

		public int Flush(byte[] output, int offset, int length)
		{
			return 0;
		}

		public byte[] ToByteArray()
		{
			return null;
		}
	}
}
