using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class X931Signer : ISigner
	{
		public const int TRAILER_IMPLICIT = 188;

		public const int TRAILER_RIPEMD160 = 12748;

		public const int TRAILER_RIPEMD128 = 13004;

		public const int TRAILER_SHA1 = 13260;

		public const int TRAILER_SHA256 = 13516;

		public const int TRAILER_SHA512 = 13772;

		public const int TRAILER_SHA384 = 14028;

		public const int TRAILER_WHIRLPOOL = 14284;

		public const int TRAILER_SHA224 = 14540;

		private IDigest digest;

		private IAsymmetricBlockCipher cipher;

		private RsaKeyParameters kParam;

		private int trailer;

		private int keyBits;

		private byte[] block;

		public virtual string AlgorithmName => null;

		public X931Signer(IAsymmetricBlockCipher cipher, IDigest digest, bool isImplicit)
		{
		}

		public X931Signer(IAsymmetricBlockCipher cipher, IDigest digest)
		{
		}

		public virtual void Init(bool forSigning, ICipherParameters parameters)
		{
		}

		private void ClearBlock(byte[] block)
		{
		}

		public virtual void Update(byte b)
		{
		}

		public virtual void BlockUpdate(byte[] input, int off, int len)
		{
		}

		public virtual void Reset()
		{
		}

		public virtual byte[] GenerateSignature()
		{
			return null;
		}

		private void CreateSignatureBlock()
		{
		}

		public virtual bool VerifySignature(byte[] signature)
		{
			return false;
		}
	}
}
