using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class Ed25519ctxSigner : ISigner
	{
		private class Buffer : MemoryStream
		{
			internal byte[] GenerateSignature(Ed25519PrivateKeyParameters privateKey, byte[] ctx)
			{
				return null;
			}

			internal bool VerifySignature(Ed25519PublicKeyParameters publicKey, byte[] ctx, byte[] signature)
			{
				return false;
			}

			internal void Reset()
			{
			}
		}

		private readonly Buffer buffer;

		private readonly byte[] context;

		private bool forSigning;

		private Ed25519PrivateKeyParameters privateKey;

		private Ed25519PublicKeyParameters publicKey;

		public virtual string AlgorithmName => null;

		public Ed25519ctxSigner(byte[] context)
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

		public virtual void Reset()
		{
		}
	}
}
