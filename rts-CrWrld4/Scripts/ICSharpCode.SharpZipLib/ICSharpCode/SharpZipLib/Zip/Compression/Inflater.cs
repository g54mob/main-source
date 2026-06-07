using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	public class Inflater
	{
		private static readonly int[] CPLENS;

		private static readonly int[] CPLEXT;

		private static readonly int[] CPDIST;

		private static readonly int[] CPDEXT;

		private int mode;

		private int readAdler;

		private int neededBits;

		private int repLength;

		private int repDist;

		private int uncomprLen;

		private bool isLastBlock;

		private long totalOut;

		private long totalIn;

		private bool noHeader;

		private StreamManipulator input;

		private OutputWindow outputWindow;

		private InflaterDynHeader dynHeader;

		private InflaterHuffmanTree litlenTree;

		private InflaterHuffmanTree distTree;

		private Adler32 adler;

		public bool IsNeedingInput => false;

		public bool IsNeedingDictionary => false;

		public bool IsFinished => false;

		public long TotalOut => 0L;

		public int RemainingInput => 0;

		public Inflater(bool noHeader)
		{
		}

		public void Reset()
		{
		}

		private bool DecodeHeader()
		{
			return false;
		}

		private bool DecodeDict()
		{
			return false;
		}

		private bool DecodeHuffman()
		{
			return false;
		}

		private bool DecodeChksum()
		{
			return false;
		}

		private bool Decode()
		{
			return false;
		}

		public void SetInput(byte[] buffer, int index, int count)
		{
		}

		public int Inflate(byte[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
