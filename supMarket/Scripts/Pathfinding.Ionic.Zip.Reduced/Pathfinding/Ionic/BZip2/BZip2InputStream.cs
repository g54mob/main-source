using System.IO;
using Pathfinding.Ionic.Crc;

namespace Pathfinding.Ionic.BZip2
{
	public class BZip2InputStream : Stream
	{
		private enum CState
		{
			EOF = 0,
			START_BLOCK = 1,
			RAND_PART_A = 2,
			RAND_PART_B = 3,
			RAND_PART_C = 4,
			NO_RAND_PART_A = 5,
			NO_RAND_PART_B = 6,
			NO_RAND_PART_C = 7
		}

		private sealed class DecompressionState
		{
			public readonly bool[] inUse;

			public readonly byte[] seqToUnseq;

			public readonly byte[] selector;

			public readonly byte[] selectorMtf;

			public readonly int[] unzftab;

			public readonly int[][] gLimit;

			public readonly int[][] gBase;

			public readonly int[][] gPerm;

			public readonly int[] gMinlen;

			public readonly int[] cftab;

			public readonly byte[] getAndMoveToFrontDecode_yy;

			public readonly char[][] temp_charArray2d;

			public readonly byte[] recvDecodingTables_pos;

			public int[] tt;

			public byte[] ll8;

			public DecompressionState(int blockSize100k)
			{
			}

			public int[] initTT(int length)
			{
				return null;
			}
		}

		private bool _disposed;

		private bool _leaveOpen;

		private long totalBytesRead;

		private int last;

		private int origPtr;

		private int blockSize100k;

		private bool blockRandomised;

		private int bsBuff;

		private int bsLive;

		private readonly CRC32 crc;

		private int nInUse;

		private Stream input;

		private int currentChar;

		private CState currentState;

		private uint storedBlockCRC;

		private uint storedCombinedCRC;

		private uint computedBlockCRC;

		private uint computedCombinedCRC;

		private int su_count;

		private int su_ch2;

		private int su_chPrev;

		private int su_i2;

		private int su_j2;

		private int su_rNToGo;

		private int su_rTPos;

		private int su_tPos;

		private char su_z;

		private DecompressionState data;

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

		public BZip2InputStream(Stream input)
		{
		}

		public BZip2InputStream(Stream input, bool leaveOpen)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		private void MakeMaps()
		{
		}

		public override int ReadByte()
		{
			return 0;
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

		protected override void Dispose(bool disposing)
		{
		}

		private void init()
		{
		}

		private void CheckMagicChar(char expected, int position)
		{
		}

		private void InitBlock()
		{
		}

		private void EndBlock()
		{
		}

		private void complete()
		{
		}

		public override void Close()
		{
		}

		private int GetBits(int n)
		{
			return 0;
		}

		private bool bsGetBit()
		{
			return false;
		}

		private char bsGetUByte()
		{
			return '\0';
		}

		private uint bsGetInt()
		{
			return 0u;
		}

		private static void hbCreateDecodeTables(int[] limit, int[] bbase, int[] perm, char[] length, int minLen, int maxLen, int alphaSize)
		{
		}

		private void recvDecodingTables()
		{
		}

		private void createHuffmanDecodingTables(int alphaSize, int nGroups)
		{
		}

		private void getAndMoveToFrontDecode()
		{
		}

		private int getAndMoveToFrontDecode0(int groupNo)
		{
			return 0;
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
	}
}
