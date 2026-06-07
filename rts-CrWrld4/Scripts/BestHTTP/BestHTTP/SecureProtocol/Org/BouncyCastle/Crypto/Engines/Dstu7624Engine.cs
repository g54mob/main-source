namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class Dstu7624Engine : IBlockCipher
	{
		private ulong[] internalState;

		private ulong[] workingKey;

		private ulong[][] roundKeys;

		private int wordsInBlock;

		private int wordsInKey;

		private const int ROUNDS_128 = 10;

		private const int ROUNDS_256 = 14;

		private const int ROUNDS_512 = 18;

		private int roundsAmount;

		private bool forEncryption;

		private const ulong mdsMatrix = 290207332435296513uL;

		private const ulong mdsInvMatrix = 14616231584692868525uL;

		private static readonly byte[] S0;

		private static readonly byte[] S1;

		private static readonly byte[] S2;

		private static readonly byte[] S3;

		private static readonly byte[] T0;

		private static readonly byte[] T1;

		private static readonly byte[] T2;

		private static readonly byte[] T3;

		public virtual string AlgorithmName => null;

		public virtual bool IsPartialBlockOkay => false;

		public Dstu7624Engine(int blockSizeBits)
		{
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		private void WorkingKeyExpandKT(ulong[] workingKey, ulong[] tempKeys)
		{
		}

		private void WorkingKeyExpandEven(ulong[] workingKey, ulong[] tempKey)
		{
		}

		private void WorkingKeyExpandOdd()
		{
		}

		public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
		{
			return 0;
		}

		private void EncryptionRound()
		{
		}

		private void DecryptionRound()
		{
		}

		private void DecryptBlock_128(byte[] input, int inOff, byte[] output, int outOff)
		{
		}

		private void EncryptBlock_128(byte[] input, int inOff, byte[] output, int outOff)
		{
		}

		private void SubBytes()
		{
		}

		private void InvSubBytes()
		{
		}

		private void ShiftRows()
		{
		}

		private void InvShiftRows()
		{
		}

		private void AddRoundKey(int round)
		{
		}

		private void SubRoundKey(int round)
		{
		}

		private void XorRoundKey(int round)
		{
		}

		private static ulong MixColumn(ulong c)
		{
			return 0uL;
		}

		private void MixColumns()
		{
		}

		private static ulong MixColumnInv(ulong c)
		{
			return 0uL;
		}

		private void MixColumnsInv()
		{
		}

		private static ulong MulX(ulong n)
		{
			return 0uL;
		}

		private static ulong MulX2(ulong n)
		{
			return 0uL;
		}

		private static ulong Rotate(int n, ulong x)
		{
			return 0uL;
		}

		private void RotateLeft(ulong[] x, ulong[] z)
		{
		}

		public virtual int GetBlockSize()
		{
			return 0;
		}

		public virtual void Reset()
		{
		}
	}
}
