using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class Ed25519Signer : ISigner
	{
		private class Buffer : MemoryStream
		{
			internal byte[] GenerateSignature(Ed25519PrivateKeyParameters privateKey)
			{
				return null;
			}

			internal bool VerifySignature(Ed25519PublicKeyParameters publicKey, byte[] signature)
			{
				return false;
			}

			internal void Reset()
			{
			}
		}

		private readonly Buffer buffer;

		private bool forSigning;

		private Ed25519PrivateKeyParameters privateKey;

		private Ed25519PublicKeyParameters publicKey;

		public virtual string AlgorithmName => null;

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

		public virtual void Reset()
		{
		}
	}
}
