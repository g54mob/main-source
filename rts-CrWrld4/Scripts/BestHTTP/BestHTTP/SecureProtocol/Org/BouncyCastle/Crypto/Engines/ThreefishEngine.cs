namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class ThreefishEngine : IBlockCipher
	{
		private abstract class ThreefishCipher
		{
			protected readonly ulong[] t;

			protected readonly ulong[] kw;

			protected ThreefishCipher(ulong[] kw, ulong[] t)
			{
			}

			internal abstract void EncryptBlock(ulong[] block, ulong[] outWords);

			internal abstract void DecryptBlock(ulong[] block, ulong[] outWords);
		}

		private sealed class Threefish256Cipher : ThreefishCipher
		{
			private const int ROTATION_0_0 = 14;

			private const int ROTATION_0_1 = 16;

			private const int ROTATION_1_0 = 52;

			private const int ROTATION_1_1 = 57;

			private const int ROTATION_2_0 = 23;

			private const int ROTATION_2_1 = 40;

			private const int ROTATION_3_0 = 5;

			private const int ROTATION_3_1 = 37;

			private const int ROTATION_4_0 = 25;

			private const int ROTATION_4_1 = 33;

			private const int ROTATION_5_0 = 46;

			private const int ROTATION_5_1 = 12;

			private const int ROTATION_6_0 = 58;

			private const int ROTATION_6_1 = 22;

			private const int ROTATION_7_0 = 32;

			private const int ROTATION_7_1 = 32;

			public Threefish256Cipher(ulong[] kw, ulong[] t)
			{
			}

			internal override void EncryptBlock(ulong[] block, ulong[] outWords)
			{
			}

			internal override void DecryptBlock(ulong[] block, ulong[] state)
			{
			}
		}

		private sealed class Threefish512Cipher : ThreefishCipher
		{
			private const int ROTATION_0_0 = 46;

			private const int ROTATION_0_1 = 36;

			private const int ROTATION_0_2 = 19;

			private const int ROTATION_0_3 = 37;

			private const int ROTATION_1_0 = 33;

			private const int ROTATION_1_1 = 27;

			private const int ROTATION_1_2 = 14;

			private const int ROTATION_1_3 = 42;

			private const int ROTATION_2_0 = 17;

			private const int ROTATION_2_1 = 49;

			private const int ROTATION_2_2 = 36;

			private const int ROTATION_2_3 = 39;

			private const int ROTATION_3_0 = 44;

			private const int ROTATION_3_1 = 9;

			private const int ROTATION_3_2 = 54;

			private const int ROTATION_3_3 = 56;

			private const int ROTATION_4_0 = 39;

			private const int ROTATION_4_1 = 30;

			private const int ROTATION_4_2 = 34;

			private const int ROTATION_4_3 = 24;

			private const int ROTATION_5_0 = 13;

			private const int ROTATION_5_1 = 50;

			private const int ROTATION_5_2 = 10;

			private const int ROTATION_5_3 = 17;

			private const int ROTATION_6_0 = 25;

			private const int ROTATION_6_1 = 29;

			private const int ROTATION_6_2 = 39;

			private const int ROTATION_6_3 = 43;

			private const int ROTATION_7_0 = 8;

			private const int ROTATION_7_1 = 35;

			private const int ROTATION_7_2 = 56;

			private const int ROTATION_7_3 = 22;

			internal Threefish512Cipher(ulong[] kw, ulong[] t)
			{
			}

			internal override void EncryptBlock(ulong[] block, ulong[] outWords)
			{
			}

			internal override void DecryptBlock(ulong[] block, ulong[] state)
			{
			}
		}

		private sealed class Threefish1024Cipher : ThreefishCipher
		{
			private const int ROTATION_0_0 = 24;

			private const int ROTATION_0_1 = 13;

			private const int ROTATION_0_2 = 8;

			private const int ROTATION_0_3 = 47;

			private const int ROTATION_0_4 = 8;

			private const int ROTATION_0_5 = 17;

			private const int ROTATION_0_6 = 22;

			private const int ROTATION_0_7 = 37;

			private const int ROTATION_1_0 = 38;

			private const int ROTATION_1_1 = 19;

			private const int ROTATION_1_2 = 10;

			private const int ROTATION_1_3 = 55;

			private const int ROTATION_1_4 = 49;

			private const int ROTATION_1_5 = 18;

			private const int ROTATION_1_6 = 23;

			private const int ROTATION_1_7 = 52;

			private const int ROTATION_2_0 = 33;

			private const int ROTATION_2_1 = 4;

			private const int ROTATION_2_2 = 51;

			private const int ROTATION_2_3 = 13;

			private const int ROTATION_2_4 = 34;

			private const int ROTATION_2_5 = 41;

			private const int ROTATION_2_6 = 59;

			private const int ROTATION_2_7 = 17;

			private const int ROTATION_3_0 = 5;

			private const int ROTATION_3_1 = 20;

			private const int ROTATION_3_2 = 48;

			private const int ROTATION_3_3 = 41;

			private const int ROTATION_3_4 = 47;

			private const int ROTATION_3_5 = 28;

			private const int ROTATION_3_6 = 16;

			private const int ROTATION_3_7 = 25;

			private const int ROTATION_4_0 = 41;

			private const int ROTATION_4_1 = 9;

			private const int ROTATION_4_2 = 37;

			private const int ROTATION_4_3 = 31;

			private const int ROTATION_4_4 = 12;

			private const int ROTATION_4_5 = 47;

			private const int ROTATION_4_6 = 44;

			private const int ROTATION_4_7 = 30;

			private const int ROTATION_5_0 = 16;

			private const int ROTATION_5_1 = 34;

			private const int ROTATION_5_2 = 56;

			private const int ROTATION_5_3 = 51;

			private const int ROTATION_5_4 = 4;

			private const int ROTATION_5_5 = 53;

			private const int ROTATION_5_6 = 42;

			private const int ROTATION_5_7 = 41;

			private const int ROTATION_6_0 = 31;

			private const int ROTATION_6_1 = 44;

			private const int ROTATION_6_2 = 47;

			private const int ROTATION_6_3 = 46;

			private const int ROTATION_6_4 = 19;

			private const int ROTATION_6_5 = 42;

			private const int ROTATION_6_6 = 44;

			private const int ROTATION_6_7 = 25;

			private const int ROTATION_7_0 = 9;

			private const int ROTATION_7_1 = 48;

			private const int ROTATION_7_2 = 35;

			private const int ROTATION_7_3 = 52;

			private const int ROTATION_7_4 = 23;

			private const int ROTATION_7_5 = 31;

			private const int ROTATION_7_6 = 37;

			private const int ROTATION_7_7 = 20;

			public Threefish1024Cipher(ulong[] kw, ulong[] t)
			{
			}

			internal override void EncryptBlock(ulong[] block, ulong[] outWords)
			{
			}

			internal override void DecryptBlock(ulong[] block, ulong[] state)
			{
			}
		}

		public const int BLOCKSIZE_256 = 256;

		public const int BLOCKSIZE_512 = 512;

		public const int BLOCKSIZE_1024 = 1024;

		private const int TWEAK_SIZE_BYTES = 16;

		private const int TWEAK_SIZE_WORDS = 2;

		private const int ROUNDS_256 = 72;

		private const int ROUNDS_512 = 72;

		private const int ROUNDS_1024 = 80;

		private const int MAX_ROUNDS = 80;

		private const ulong C_240 = 2004413935125273122uL;

		private static readonly int[] MOD9;

		private static readonly int[] MOD17;

		private static readonly int[] MOD5;

		private static readonly int[] MOD3;

		private readonly int blocksizeBytes;

		private readonly int blocksizeWords;

		private readonly ulong[] currentBlock;

		private readonly ulong[] t;

		private readonly ulong[] kw;

		private readonly ThreefishCipher cipher;

		private bool forEncryption;

		public virtual string AlgorithmName => null;

		public virtual bool IsPartialBlockOkay => false;

		static ThreefishEngine()
		{
		}

		public ThreefishEngine(int blocksizeBits)
		{
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		internal void Init(bool forEncryption, ulong[] key, ulong[] tweak)
		{
		}

		private void SetKey(ulong[] key)
		{
		}

		private void SetTweak(ulong[] tweak)
		{
		}

		public virtual int GetBlockSize()
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		public virtual int ProcessBlock(byte[] inBytes, int inOff, byte[] outBytes, int outOff)
		{
			return 0;
		}

		internal int ProcessBlock(ulong[] inWords, ulong[] outWords)
		{
			return 0;
		}

		internal static ulong BytesToWord(byte[] bytes, int off)
		{
			return 0uL;
		}

		internal static void WordToBytes(ulong word, byte[] bytes, int off)
		{
		}

		private static ulong RotlXor(ulong x, int n, ulong xor)
		{
			return 0uL;
		}

		private static ulong XorRotr(ulong x, int n, ulong xor)
		{
			return 0uL;
		}
	}
}
