using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	public class Inflater
	{
		private static readonly int[] CPLENS;

		private static readonly int[] CPLEXT;

		private static readonly int[] CPDIST;

		private static readonly int[] CPDEXT;

		private const int DECODE_HEADER = 0;

		private const int DECODE_DICT = 1;

		private const int DECODE_BLOCKS = 2;

		private const int DECODE_STORED_LEN1 = 3;

		private const int DECODE_STORED_LEN2 = 4;

		private const int DECODE_STORED = 5;

		private const int DECODE_DYN_HEADER = 6;

		private const int DECODE_HUFFMAN = 7;

		private const int DECODE_HUFFMAN_LENBITS = 8;

		private const int DECODE_HUFFMAN_DIST = 9;

		private const int DECODE_HUFFMAN_DISTBITS = 10;

		private const int DECODE_CHKSUM = 11;

		private const int FINISHED = 12;

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

		private readonly StreamManipulator input;

		private OutputWindow outputWindow;

		private InflaterDynHeader dynHeader;

		private InflaterHuffmanTree litlenTree;

		private InflaterHuffmanTree distTree;

		private Adler32 adler;

		public bool IsNeedingInput => false;

		public bool IsNeedingDictionary => false;

		public bool IsFinished => false;

		public int Adler => 0;

		public long TotalOut => 0L;

		public long TotalIn => 0L;

		public int RemainingInput => 0;

		public Inflater()
		{
		}

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

		public void SetDictionary(byte[] buffer)
		{
		}

		public void SetDictionary(byte[] buffer, int index, int count)
		{
		}

		public void SetInput(byte[] buffer)
		{
		}

		public void SetInput(byte[] buffer, int index, int count)
		{
		}

		public int Inflate(byte[] buffer)
		{
			return 0;
		}

		public int Inflate(byte[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
