using System.IO;

namespace ThreeDISevenZeroR.UnityGifDecoder
{
	public class GifBitBlockReader
	{
		private Stream stream;

		private int currentByte;

		private int currentBitPosition;

		private int currentBufferPosition;

		private int currentBufferSize;

		private bool endReached;

		private readonly byte[] buffer;

		public GifBitBlockReader()
		{
		}

		public GifBitBlockReader(Stream stream)
		{
		}

		public void SetStream(Stream stream)
		{
		}

		public void StartNewReading()
		{
		}

		public void FinishReading()
		{
		}

		public int ReadBits(int count)
		{
			return 0;
		}

		private void ReadNextBlock()
		{
		}
	}
}
