using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Encodings
{
	public class OaepEncoding : IAsymmetricBlockCipher
	{
		private byte[] defHash;

		private IDigest mgf1Hash;

		private IAsymmetricBlockCipher engine;

		private SecureRandom random;

		private bool forEncryption;

		public string AlgorithmName => null;

		public OaepEncoding(IAsymmetricBlockCipher cipher)
		{
		}

		public OaepEncoding(IAsymmetricBlockCipher cipher, IDigest hash)
		{
		}

		public OaepEncoding(IAsymmetricBlockCipher cipher, IDigest hash, byte[] encodingParams)
		{
		}

		public OaepEncoding(IAsymmetricBlockCipher cipher, IDigest hash, IDigest mgf1Hash, byte[] encodingParams)
		{
		}

		public IAsymmetricBlockCipher GetUnderlyingCipher()
		{
			return null;
		}

		public void Init(bool forEncryption, ICipherParameters param)
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

		public byte[] ProcessBlock(byte[] inBytes, int inOff, int inLen)
		{
			return null;
		}

		private byte[] EncodeBlock(byte[] inBytes, int inOff, int inLen)
		{
			return null;
		}

		private byte[] DecodeBlock(byte[] inBytes, int inOff, int inLen)
		{
			return null;
		}

		private void ItoOSP(int i, byte[] sp)
		{
		}

		private byte[] maskGeneratorFunction1(byte[] Z, int zOff, int zLen, int length)
		{
			return null;
		}
	}
}
