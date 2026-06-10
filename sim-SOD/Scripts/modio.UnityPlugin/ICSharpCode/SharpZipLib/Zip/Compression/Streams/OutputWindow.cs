namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
	public class OutputWindow
	{
		private const int WindowSize = 32768;

		private const int WindowMask = 32767;

		private byte[] window;

		private int windowEnd;

		private int windowFilled;

		public void Write(int value)
		{
		}

		private void SlowRepeat(int repStart, int length, int distance)
		{
		}

		public void Repeat(int length, int distance)
		{
		}

		public int CopyStored(StreamManipulator input, int length)
		{
			return 0;
		}

		public void CopyDict(byte[] dictionary, int offset, int length)
		{
		}

		public int GetFreeSpace()
		{
			return 0;
		}

		public int GetAvailable()
		{
			return 0;
		}

		public int CopyOutput(byte[] output, int offset, int len)
		{
			return 0;
		}

		public void Reset()
		{
		}
	}
}
