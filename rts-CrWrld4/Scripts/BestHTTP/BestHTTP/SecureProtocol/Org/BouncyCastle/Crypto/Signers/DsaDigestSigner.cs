using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class DsaDigestSigner : ISigner
	{
		private readonly IDsa dsa;

		private readonly IDigest digest;

		private readonly IDsaEncoding encoding;

		private bool forSigning;

		public virtual string AlgorithmName => null;

		public DsaDigestSigner(IDsa dsa, IDigest digest)
		{
		}

		public DsaDigestSigner(IDsaExt dsa, IDigest digest, IDsaEncoding encoding)
		{
		}

		public virtual void Init(bool forSigning, ICipherParameters parameters)
		{
		}

		public virtual void Update(byte input)
		{
		}

		public virtual void BlockUpdate(byte[] input, int inOff, int length)
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

		public virtual void Reset()
		{
		}

		protected virtual BigInteger GetOrder()
		{
			return null;
		}
	}
}
