using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class Ed25519phSigner : ISigner
	{
		private readonly IDigest prehash;

		private readonly byte[] context;

		private bool forSigning;

		private Ed25519PrivateKeyParameters privateKey;

		private Ed25519PublicKeyParameters publicKey;

		public virtual string AlgorithmName => null;

		public Ed25519phSigner(byte[] context)
		{
		}

		public virtual void Init(bool forSigning, ICipherParameters parameters)
		{
		}

		public virtual void Update(byte b)
		{
		}

		public virtual void BlockUpdate(byte[] buf, int off, int len)
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

		public void Reset()
		{
		}
	}
}
