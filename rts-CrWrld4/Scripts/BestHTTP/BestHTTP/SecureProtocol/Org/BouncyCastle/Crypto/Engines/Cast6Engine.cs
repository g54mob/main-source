namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public sealed class Cast6Engine : Cast5Engine
	{
		private const int ROUNDS = 12;

		private const int BLOCK_SIZE = 16;

		private int[] _Kr;

		private uint[] _Km;

		private int[] _Tr;

		private uint[] _Tm;

		private uint[] _workingKey;

		public override string AlgorithmName => null;

		public override void Reset()
		{
		}

		public override int GetBlockSize()
		{
			return 0;
		}

		internal override void SetKey(byte[] key)
		{
		}

		internal override int EncryptBlock(byte[] src, int srcIndex, byte[] dst, int dstIndex)
		{
			return 0;
		}

		internal override int DecryptBlock(byte[] src, int srcIndex, byte[] dst, int dstIndex)
		{
			return 0;
		}

		private void CAST_Encipher(uint A, uint B, uint C, uint D, uint[] result)
		{
		}

		private void CAST_Decipher(uint A, uint B, uint C, uint D, uint[] result)
		{
		}
	}
}
