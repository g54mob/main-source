namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
	public class StreamManipulator
	{
		private byte[] window_;

		private int windowStart_;

		private int windowEnd_;

		private uint buffer_;

		private int bitsInBuffer_;

		public int AvailableBits => 0;

		public int AvailableBytes => 0;

		public bool IsNeedingInput => false;

		public int PeekBits(int bitCount)
		{
			return 0;
		}

		public void DropBits(int bitCount)
		{
		}

		public int GetBits(int bitCount)
		{
			return 0;
		}

		public void SkipToByteBoundary()
		{
		}

		public int CopyBytes(byte[] output, int offset, int length)
		{
			return 0;
		}

		public void Reset()
		{
		}

		public void SetInput(byte[] buffer, int offset, int count)
		{
		}
	}
}
