using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Encodings
{
	public class Pkcs1Encoding : IAsymmetricBlockCipher
	{
		public const string StrictLengthEnabledProperty = "BestHTTP.SecureProtocol.Org.BouncyCastle.Pkcs1.Strict";

		private const int HeaderLength = 10;

		private static readonly bool[] strictLengthEnabled;

		private SecureRandom random;

		private IAsymmetricBlockCipher engine;

		private bool forEncryption;

		private bool forPrivateKey;

		private bool useStrictLength;

		private int pLen;

		private byte[] fallback;

		private byte[] blockBuffer;

		public static bool StrictLengthEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string AlgorithmName => null;

		static Pkcs1Encoding()
		{
		}

		public Pkcs1Encoding(IAsymmetricBlockCipher cipher)
		{
		}

		public Pkcs1Encoding(IAsymmetricBlockCipher cipher, int pLen)
		{
		}

		public Pkcs1Encoding(IAsymmetricBlockCipher cipher, byte[] fallback)
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

		public byte[] ProcessBlock(byte[] input, int inOff, int length)
		{
			return null;
		}

		private byte[] EncodeBlock(byte[] input, int inOff, int inLen)
		{
			return null;
		}

		private static int CheckPkcs1Encoding(byte[] encoded, int pLen)
		{
			return 0;
		}

		private byte[] DecodeBlockOrRandom(byte[] input, int inOff, int inLen)
		{
			return null;
		}

		private byte[] DecodeBlock(byte[] input, int inOff, int inLen)
		{
			return null;
		}

		private int FindStart(byte type, byte[] block)
		{
			return 0;
		}
	}
}
