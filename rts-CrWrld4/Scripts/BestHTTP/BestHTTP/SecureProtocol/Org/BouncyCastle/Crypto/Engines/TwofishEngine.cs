namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public sealed class TwofishEngine : IBlockCipher
	{
		private static readonly byte[,] P;

		private const int P_00 = 1;

		private const int P_01 = 0;

		private const int P_02 = 0;

		private const int P_03 = 1;

		private const int P_04 = 1;

		private const int P_10 = 0;

		private const int P_11 = 0;

		private const int P_12 = 1;

		private const int P_13 = 1;

		private const int P_14 = 0;

		private const int P_20 = 1;

		private const int P_21 = 1;

		private const int P_22 = 0;

		private const int P_23 = 0;

		private const int P_24 = 0;

		private const int P_30 = 0;

		private const int P_31 = 1;

		private const int P_32 = 1;

		private const int P_33 = 0;

		private const int P_34 = 1;

		private const int GF256_FDBK = 361;

		private const int GF256_FDBK_2 = 180;

		private const int GF256_FDBK_4 = 90;

		private const int RS_GF_FDBK = 333;

		private const int ROUNDS = 16;

		private const int MAX_ROUNDS = 16;

		private const int BLOCK_SIZE = 16;

		private const int MAX_KEY_BITS = 256;

		private const int INPUT_WHITEN = 0;

		private const int OUTPUT_WHITEN = 4;

		private const int ROUND_SUBKEYS = 8;

		private const int TOTAL_SUBKEYS = 40;

		private const int SK_STEP = 33686018;

		private const int SK_BUMP = 16843009;

		private const int SK_ROTL = 9;

		private bool encrypting;

		private int[] gMDS0;

		private int[] gMDS1;

		private int[] gMDS2;

		private int[] gMDS3;

		private int[] gSubKeys;

		private int[] gSBox;

		private int k64Cnt;

		private byte[] workingKey;

		public string AlgorithmName => null;

		public bool IsPartialBlockOkay => false;

		public void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}

		public int GetBlockSize()
		{
			return 0;
		}

		private void SetKey(byte[] key)
		{
		}

		private void EncryptBlock(byte[] src, int srcIndex, byte[] dst, int dstIndex)
		{
		}

		private void DecryptBlock(byte[] src, int srcIndex, byte[] dst, int dstIndex)
		{
		}

		private int F32(int x, int[] k32)
		{
			return 0;
		}

		private int RS_MDS_Encode(int k0, int k1)
		{
			return 0;
		}

		private int RS_rem(int x)
		{
			return 0;
		}

		private int LFSR1(int x)
		{
			return 0;
		}

		private int LFSR2(int x)
		{
			return 0;
		}

		private int Mx_X(int x)
		{
			return 0;
		}

		private int Mx_Y(int x)
		{
			return 0;
		}

		private int M_b0(int x)
		{
			return 0;
		}

		private int M_b1(int x)
		{
			return 0;
		}

		private int M_b2(int x)
		{
			return 0;
		}

		private int M_b3(int x)
		{
			return 0;
		}

		private int Fe32_0(int x)
		{
			return 0;
		}

		private int Fe32_3(int x)
		{
			return 0;
		}

		private int BytesTo32Bits(byte[] b, int p)
		{
			return 0;
		}

		private void Bits32ToBytes(int inData, byte[] b, int offset)
		{
		}
	}
}
