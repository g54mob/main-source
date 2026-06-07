using Pathfinding.Ionic.Crc;

namespace Pathfinding.Ionic.BZip2
{
	internal class BZip2Compressor
	{
		private class CompressionState
		{
			public readonly bool[] inUse;

			public readonly byte[] unseqToSeq;

			public readonly int[] mtfFreq;

			public readonly byte[] selector;

			public readonly byte[] selectorMtf;

			public readonly byte[] generateMTFValues_yy;

			public byte[][] sendMTFValues_len;

			public int[][] sendMTFValues_rfreq;

			public readonly int[] sendMTFValues_fave;

			public readonly short[] sendMTFValues_cost;

			public int[][] sendMTFValues_code;

			public readonly byte[] sendMTFValues2_pos;

			public readonly bool[] sentMTFValues4_inUse16;

			public readonly int[] stack_ll;

			public readonly int[] stack_hh;

			public readonly int[] stack_dd;

			public readonly int[] mainSort_runningOrder;

			public readonly int[] mainSort_copy;

			public readonly bool[] mainSort_bigDone;

			public int[] heap;

			public int[] weight;

			public int[] parent;

			public readonly int[] ftab;

			public byte[] block;

			public int[] fmap;

			public char[] sfmap;

			public char[] quadrant;

			public CompressionState(int blockSize100k)
			{
			}
		}

		private int blockSize100k;

		private int currentByte;

		private int runLength;

		private int last;

		private int outBlockFillThreshold;

		private CompressionState cstate;

		private readonly CRC32 crc;

		private BitWriter bw;

		private int runs;

		private int workDone;

		private int workLimit;

		private bool firstAttempt;

		private bool blockRandomised;

		private int origPtr;

		private int nInUse;

		private int nMTF;

		private static readonly int SETMASK;

		private static readonly int CLEARMASK;

		private static readonly byte GREATER_ICOST;

		private static readonly byte LESSER_ICOST;

		private static readonly int SMALL_THRESH;

		private static readonly int DEPTH_THRESH;

		private static readonly int WORK_FACTOR;

		private static readonly int[] increments;

		public int BlockSize => 0;

		public uint Crc32 { get; private set; }

		public int AvailableBytesOut { get; private set; }

		public int UncompressedBytes => 0;

		public BZip2Compressor(BitWriter writer)
		{
		}

		public BZip2Compressor(BitWriter writer, int blockSize)
		{
		}

		private void Reset()
		{
		}

		public int Fill(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		private int write0(byte b)
		{
			return 0;
		}

		private bool AddRunToOutputBlock(bool final)
		{
			return false;
		}

		public void CompressAndWrite()
		{
		}

		private void randomiseBlock()
		{
		}

		private void mainSort()
		{
		}

		private void blockSort()
		{
		}

		private bool mainSimpleSort(CompressionState dataShadow, int lo, int hi, int d)
		{
			return false;
		}

		private static void vswap(int[] fmap, int p1, int p2, int n)
		{
		}

		private static byte med3(byte a, byte b, byte c)
		{
			return 0;
		}

		private void mainQSort3(CompressionState dataShadow, int loSt, int hiSt, int dSt)
		{
		}

		private void generateMTFValues()
		{
		}

		private static void hbAssignCodes(int[] code, byte[] length, int minLen, int maxLen, int alphaSize)
		{
		}

		private void sendMTFValues()
		{
		}

		private void sendMTFValues0(int nGroups, int alphaSize)
		{
		}

		private static void hbMakeCodeLengths(byte[] len, int[] freq, CompressionState state1, int alphaSize, int maxLen)
		{
		}

		private int sendMTFValues1(int nGroups, int alphaSize)
		{
			return 0;
		}

		private void sendMTFValues2(int nGroups, int nSelectors)
		{
		}

		private void sendMTFValues3(int nGroups, int alphaSize)
		{
		}

		private void sendMTFValues4()
		{
		}

		private void sendMTFValues5(int nGroups, int nSelectors)
		{
		}

		private void sendMTFValues6(int nGroups, int alphaSize)
		{
		}

		private void sendMTFValues7(int nSelectors)
		{
		}

		private void moveToFrontCodeAndSend()
		{
		}
	}
}
