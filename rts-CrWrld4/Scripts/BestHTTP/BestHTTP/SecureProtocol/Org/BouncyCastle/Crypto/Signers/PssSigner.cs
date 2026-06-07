using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class PssSigner : ISigner
	{
		public const byte TrailerImplicit = 188;

		private readonly IDigest contentDigest1;

		private readonly IDigest contentDigest2;

		private readonly IDigest mgfDigest;

		private readonly IAsymmetricBlockCipher cipher;

		private SecureRandom random;

		private int hLen;

		private int mgfhLen;

		private int sLen;

		private bool sSet;

		private int emBits;

		private byte[] salt;

		private byte[] mDash;

		private byte[] block;

		private byte trailer;

		public virtual string AlgorithmName => null;

		public static PssSigner CreateRawSigner(IAsymmetricBlockCipher cipher, IDigest digest)
		{
			return null;
		}

		public static PssSigner CreateRawSigner(IAsymmetricBlockCipher cipher, IDigest contentDigest, IDigest mgfDigest, int saltLen, byte trailer)
		{
			return null;
		}

		public PssSigner(IAsymmetricBlockCipher cipher, IDigest digest)
		{
		}

		public PssSigner(IAsymmetricBlockCipher cipher, IDigest digest, int saltLen)
		{
		}

		public PssSigner(IAsymmetricBlockCipher cipher, IDigest digest, byte[] salt)
		{
		}

		public PssSigner(IAsymmetricBlockCipher cipher, IDigest contentDigest, IDigest mgfDigest, int saltLen)
		{
		}

		public PssSigner(IAsymmetricBlockCipher cipher, IDigest contentDigest, IDigest mgfDigest, byte[] salt)
		{
		}

		public PssSigner(IAsymmetricBlockCipher cipher, IDigest digest, int saltLen, byte trailer)
		{
		}

		public PssSigner(IAsymmetricBlockCipher cipher, IDigest contentDigest, IDigest mgfDigest, int saltLen, byte trailer)
		{
		}

		private PssSigner(IAsymmetricBlockCipher cipher, IDigest contentDigest1, IDigest contentDigest2, IDigest mgfDigest, int saltLen, byte[] salt, byte trailer)
		{
		}

		public virtual void Init(bool forSigning, ICipherParameters parameters)
		{
		}

		private void ClearBlock(byte[] block)
		{
		}

		public virtual void Update(byte input)
		{
		}

		public virtual void BlockUpdate(byte[] input, int inOff, int length)
		{
		}

		public virtual void Reset()
		{
		}

		public virtual byte[] GenerateSignature()
		{
			return null;
		}

		public virtual bool VerifySignature(byte[] signature)
		{
			return false;
		}

		private void ItoOSP(int i, byte[] sp)
		{
		}

		private byte[] MaskGeneratorFunction1(byte[] Z, int zOff, int zLen, int length)
		{
			return null;
		}
	}
}
