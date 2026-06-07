using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class Ed448phSigner : ISigner
	{
		private readonly IXof prehash;

		private readonly byte[] context;

		private bool forSigning;

		private Ed448PrivateKeyParameters privateKey;

		private Ed448PublicKeyParameters publicKey;

		public virtual string AlgorithmName => null;

		public Ed448phSigner(byte[] context)
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
