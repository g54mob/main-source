using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Encodings
{
	public class ISO9796d1Encoding : IAsymmetricBlockCipher
	{
		private static readonly BigInteger Sixteen;

		private static readonly BigInteger Six;

		private static readonly byte[] shadows;

		private static readonly byte[] inverse;

		private readonly IAsymmetricBlockCipher engine;

		private bool forEncryption;

		private int bitSize;

		private int padBits;

		private BigInteger modulus;

		public string AlgorithmName => null;

		public ISO9796d1Encoding(IAsymmetricBlockCipher cipher)
		{
		}

		public IAsymmetricBlockCipher GetUnderlyingCipher()
		{
			return null;
		}

		public void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public int GetInputBlockSize()
		{
			return 0;
		}

		public int GetOutputBlockSize()
		{
			return 0;
		}

		public void SetPadBits(int padBits)
		{
		}

		public int GetPadBits()
		{
			return 0;
		}

		public byte[] ProcessBlock(byte[] input, int inOff, int length)
		{
			return null;
		}

		private byte[] EncodeBlock(byte[] input, int inOff, int inLen)
		{
			return null;
		}

		private byte[] DecodeBlock(byte[] input, int inOff, int inLen)
		{
			return null;
		}
	}
}
