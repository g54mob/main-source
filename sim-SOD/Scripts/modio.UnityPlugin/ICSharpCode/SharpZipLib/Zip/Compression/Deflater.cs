namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	public class Deflater
	{
		public enum CompressionLevel
		{
			BEST_COMPRESSION = 9,
			BEST_SPEED = 1,
			DEFAULT_COMPRESSION = -1,
			NO_COMPRESSION = 0,
			DEFLATED = 8
		}

		public const int BEST_COMPRESSION = 9;

		public const int BEST_SPEED = 1;

		public const int DEFAULT_COMPRESSION = -1;

		public const int NO_COMPRESSION = 0;

		public const int DEFLATED = 8;

		private const int IS_SETDICT = 1;

		private const int IS_FLUSHING = 4;

		private const int IS_FINISHING = 8;

		private const int INIT_STATE = 0;

		private const int SETDICT_STATE = 1;

		private const int BUSY_STATE = 16;

		private const int FLUSHING_STATE = 20;

		private const int FINISHING_STATE = 28;

		private const int FINISHED_STATE = 30;

		private const int CLOSED_STATE = 127;

		private int level;

		private bool noZlibHeaderOrFooter;

		private int state;

		private long totalOut;

		private DeflaterPending pending;

		private DeflaterEngine engine;

		public int Adler => 0;

		public long TotalIn => 0L;

		public long TotalOut => 0L;

		public bool IsFinished => false;

		public bool IsNeedingInput => false;

		public Deflater()
		{
		}

		public Deflater(int level)
		{
		}

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

		public void SetInput(byte[] input)
		{
		}

		public void SetInput(byte[] input, int offset, int count)
		{
		}

		public void SetLevel(int level)
		{
		}

		public int GetLevel()
		{
			return 0;
		}

		public void SetStrategy(DeflateStrategy strategy)
		{
		}

		public int Deflate(byte[] output)
		{
			return 0;
		}

		public int Deflate(byte[] output, int offset, int length)
		{
			return 0;
		}

		public void SetDictionary(byte[] dictionary)
		{
		}

		public void SetDictionary(byte[] dictionary, int index, int count)
		{
		}
	}
}
