namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	public class DeflaterHuffman
	{
		private class Tree
		{
			public short[] freqs;

			public byte[] length;

			public int minNumCodes;

			public int numCodes;

			private short[] codes;

			private int[] bl_counts;

			private int maxLength;

			private DeflaterHuffman dh;

			public Tree(DeflaterHuffman dh, int elems, int minCodes, int maxLength)
			{
			}

			public void Reset()
			{
			}

			public void WriteSymbol(int code)
			{
			}

			public void CheckEmpty()
			{
			}

			public void SetStaticCodes(short[] staticCodes, byte[] staticLengths)
			{
			}

			public void BuildCodes()
			{
			}

			public void BuildTree()
			{
			}

			public int GetEncodedLength()
			{
				return 0;
			}

			public void CalcBLFreq(Tree blTree)
			{
			}

			public void WriteTree(Tree blTree)
			{
			}

			private void BuildLength(int[] childs)
			{
			}
		}

		private const int BUFSIZE = 16384;

		private const int LITERAL_NUM = 286;

		private const int DIST_NUM = 30;

		private const int BITLEN_NUM = 19;

		private const int REP_3_6 = 16;

		private const int REP_3_10 = 17;

		private const int REP_11_138 = 18;

		private const int EOF_SYMBOL = 256;

		private static readonly int[] BL_ORDER;

		private static readonly byte[] bit4Reverse;

		private static short[] staticLCodes;

		private static byte[] staticLLength;

		private static short[] staticDCodes;

		private static byte[] staticDLength;

		public DeflaterPending pending;

		private Tree literalTree;

		private Tree distTree;

		private Tree blTree;

		private short[] d_buf;

		private byte[] l_buf;

		private int last_lit;

		private int extra_bits;

		static DeflaterHuffman()
		{
		}

		public DeflaterHuffman(DeflaterPending pending)
		{
		}

		public void Reset()
		{
		}

		public void SendAllTrees(int blTreeCodes)
		{
		}

		public void CompressBlock()
		{
		}

		public void FlushStoredBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
		{
		}

		public void FlushBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
		{
		}

		public bool IsFull()
		{
			return false;
		}

		public bool TallyLit(int literal)
		{
			return false;
		}

		public bool TallyDist(int distance, int length)
		{
			return false;
		}

		public static short BitReverse(int toReverse)
		{
			return 0;
		}

		private static int Lcode(int length)
		{
			return 0;
		}

		private static int Dcode(int distance)
		{
			return 0;
		}
	}
}
