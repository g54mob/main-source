namespace NAudio.Utils
{
	public class CircularBuffer
	{
		private readonly byte[] buffer;

		private readonly object lockObject;

		private int writePosition;

		private int readPosition;

		private int byteCount;

		public int MaxLength => 0;

		public int Count => 0;

		public CircularBuffer(int size)
		{
		}

		public int Write(byte[] data, int offset, int count)
		{
			return 0;
		}

		public int Read(byte[] data, int offset, int count)
		{
			return 0;
		}

		public void Reset()
		{
		}

		private void ResetInner()
		{
		}

		public void Advance(int count)
		{
		}
	}
}
