using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class RsaDigestSigner : ISigner
	{
		private readonly IAsymmetricBlockCipher rsaEngine;

		private readonly AlgorithmIdentifier algId;

		private readonly IDigest digest;

		private bool forSigning;

		private static readonly IDictionary oidMap;

		public virtual string AlgorithmName => null;

		static RsaDigestSigner()
		{
		}

		public RsaDigestSigner(IDigest digest)
		{
		}

		public RsaDigestSigner(IDigest digest, DerObjectIdentifier digestOid)
		{
		}

		public RsaDigestSigner(IDigest digest, AlgorithmIdentifier algId)
		{
		}

		public RsaDigestSigner(IRsa rsa, IDigest digest, DerObjectIdentifier digestOid)
		{
		}

		public RsaDigestSigner(IRsa rsa, IDigest digest, AlgorithmIdentifier algId)
		{
		}

		public RsaDigestSigner(IAsymmetricBlockCipher rsaEngine, IDigest digest, AlgorithmIdentifier algId)
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

		private byte[] DerEncode(byte[] hash)
		{
			return null;
		}
	}
}
