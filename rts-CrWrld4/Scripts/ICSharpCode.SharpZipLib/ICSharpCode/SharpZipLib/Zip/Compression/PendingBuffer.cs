namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	public class PendingBuffer
	{
		private byte[] buffer_;

		private int start;

		private int end;

		private uint bits;

		private int bitCount;

		public int BitCount => 0;

		public bool IsFlushed => false;

		public PendingBuffer(int bufferSize)
		{
		}

		public void Reset()
		{
		}

		public void WriteShort(int value)
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
	}
}
