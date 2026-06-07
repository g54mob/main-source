using System.IO;
using ICSharpCode.SharpZipLib.Checksums;

namespace ICSharpCode.SharpZipLib.BZip2
{
	public class BZip2OutputStream : Stream
	{
		private struct StackElement
		{
			public int ll;

			public int hh;

			public int dd;
		}

		private const int SETMASK = 2097152;

		private const int CLEARMASK = -2097153;

		private const int GREATER_ICOST = 15;

		private const int LESSER_ICOST = 0;

		private const int SMALL_THRESH = 20;

		private const int DEPTH_THRESH = 10;

		private const int QSORT_STACK_SIZE = 1000;

		private readonly int[] increments;

		private bool isStreamOwner;

		private int last;

		private int origPtr;

		private int blockSize100k;

		private bool blockRandomised;

		private int bytesOut;

		private int bsBuff;

		private int bsLive;

		private IChecksum mCrc;

		private bool[] inUse;

		private int nInUse;

		private char[] seqToUnseq;

		private char[] unseqToSeq;

		private char[] selector;

		private char[] selectorMtf;

		private byte[] block;

		private int[] quadrant;

		private int[] zptr;

		private short[] szptr;

		private int[] ftab;

		private int nMTF;

		private int[] mtfFreq;

		private int workFactor;

		private int workDone;

		private int workLimit;

		private bool firstAttempt;

		private int nBlocksRandomised;

		private int currentChar;

		private int runLength;

		private uint blockCRC;

		private uint combinedCRC;

		private int allowableBlockSize;

		private Stream baseStream;

		private bool disposed_;

		public bool IsStreamOwner
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length => 0L;

		public override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public int BytesWritten => 0;

		public BZip2OutputStream(Stream stream)
		{
		}

		public BZip2OutputStream(Stream stream, int blockSize)
		{
		}

		~BZip2OutputStream()
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override int ReadByte()
		{
			return 0;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override void WriteByte(byte value)
		{
		}

		public override void Close()
		{
		}

		private void MakeMaps()
		{
		}

		private void WriteRun()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override void Flush()
		{
		}

		private void Initialize()
		{
		}

		private void InitBlock()
		{
		}

		private void EndBlock()
		{
		}

		private void EndCompression()
		{
		}

		private void BsSetStream(Stream stream)
		{
		}

		private void BsFinishedWithStream()
		{
		}

		private void BsW(int n, int v)
		{
		}

		private void BsPutUChar(int c)
		{
		}

		private void BsPutint(int u)
		{
		}

		private void BsPutIntVS(int numBits, int c)
		{
		}

		private void SendMTFValues()
		{
		}

		private void MoveToFrontCodeAndSend()
		{
		}

		private void SimpleSort(int lo, int hi, int d)
		{
		}

		private void Vswap(int p1, int p2, int n)
		{
		}

		private void QSort3(int loSt, int hiSt, int dSt)
		{
		}

		private void MainSort()
		{
		}

		private void RandomiseBlock()
		{
		}

		private void DoReversibleTransformation()
		{
		}

		private bool FullGtU(int i1, int i2)
		{
			return false;
		}

		private void AllocateCompressStructures()
		{
		}

		private void GenerateMTFValues()
		{
		}

		private static void Panic()
		{
		}

		private static void HbMakeCodeLengths(char[] len, int[] freq, int alphaSize, int maxLen)
		{
		}

		private static void HbAssignCodes(int[] code, char[] length, int minLen, int maxLen, int alphaSize)
		{
		}

		private static byte Med3(byte a, byte b, byte c)
		{
			return 0;
		}
	}
}
