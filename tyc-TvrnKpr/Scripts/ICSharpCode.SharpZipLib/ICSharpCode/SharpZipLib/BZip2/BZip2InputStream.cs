using System.IO;
using ICSharpCode.SharpZipLib.Checksums;

namespace ICSharpCode.SharpZipLib.BZip2
{
	public class BZip2InputStream : Stream
	{
		private const int START_BLOCK_STATE = 1;

		private const int RAND_PART_A_STATE = 2;

		private const int RAND_PART_B_STATE = 3;

		private const int RAND_PART_C_STATE = 4;

		private const int NO_RAND_PART_A_STATE = 5;

		private const int NO_RAND_PART_B_STATE = 6;

		private const int NO_RAND_PART_C_STATE = 7;

		private int last;

		private int origPtr;

		private int blockSize100k;

		private bool blockRandomised;

		private int bsBuff;

		private int bsLive;

		private IChecksum mCrc;

		private bool[] inUse;

		private int nInUse;

		private byte[] seqToUnseq;

		private byte[] unseqToSeq;

		private byte[] selector;

		private byte[] selectorMtf;

		private int[] tt;

		private byte[] ll8;

		private int[] unzftab;

		private int[][] limit;

		private int[][] baseArray;

		private int[][] perm;

		private int[] minLens;

		private Stream baseStream;

		private bool streamEnd;

		private int currentChar;

		private int currentState;

		private int storedBlockCRC;

		private int storedCombinedCRC;

		private int computedBlockCRC;

		private uint computedCombinedCRC;

		private int count;

		private int chPrev;

		private int ch2;

		private int tPos;

		private int rNToGo;

		private int rTPos;

		private int i2;

		private int j2;

		private byte z;

		private bool isStreamOwner;

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

		public BZip2InputStream(Stream stream)
		{
		}

		public override void Flush()
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override void WriteByte(byte value)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override void Close()
		{
		}

		public override int ReadByte()
		{
			return 0;
		}

		private void MakeMaps()
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

		private void Complete()
		{
		}

		private void BsSetStream(Stream stream)
		{
		}

		private void FillBuffer()
		{
		}

		private int BsR(int n)
		{
			return 0;
		}

		private char BsGetUChar()
		{
			return '\0';
		}

		private int BsGetIntVS(int numBits)
		{
			return 0;
		}

		private int BsGetInt32()
		{
			return 0;
		}

		private void RecvDecodingTables()
		{
		}

		private void GetAndMoveToFrontDecode()
		{
		}

		private void SetupBlock()
		{
		}

		private void SetupRandPartA()
		{
		}

		private void SetupNoRandPartA()
		{
		}

		private void SetupRandPartB()
		{
		}

		private void SetupRandPartC()
		{
		}

		private void SetupNoRandPartB()
		{
		}

		private void SetupNoRandPartC()
		{
		}

		private void SetDecompressStructureSizes(int newSize100k)
		{
		}

		private static void CompressedStreamEOF()
		{
		}

		private static void BlockOverrun()
		{
		}

		private static void BadBlockHeader()
		{
		}

		private static void CrcError()
		{
		}

		private static void HbCreateDecodeTables(int[] limit, int[] baseArray, int[] perm, char[] length, int minLen, int maxLen, int alphaSize)
		{
		}
	}
}
