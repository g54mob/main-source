namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	public class Deflater
	{
		private int level;

		private bool noZlibHeaderOrFooter;

		private int state;

		private long totalOut;

		private DeflaterPending pending;

		private DeflaterEngine engine;

		public long TotalIn => 0L;

		public bool IsFinished => false;

		public bool IsNeedingInput => false;

		public Deflater(int level, bool noZlibHeaderOrFooter)
		{
		}

		public void Reset()
		{
		}

		public void Flush()
		{
		}

		public void Finish()
		{
		}

		public void SetInput(byte[] input, int offset, int count)
		{
		}

		public void SetLevel(int level)
		{
		}

		public void SetStrategy(DeflateStrategy strategy)
		{
		}

		public int Deflate(byte[] output, int offset, int length)
		{
			return 0;
		}
	}
}
