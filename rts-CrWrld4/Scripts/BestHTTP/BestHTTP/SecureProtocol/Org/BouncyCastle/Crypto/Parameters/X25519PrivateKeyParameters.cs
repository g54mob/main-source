using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public sealed class X25519PrivateKeyParameters : AsymmetricKeyParameter
	{
		public static readonly int KeySize;

		public static readonly int SecretSize;

		private readonly byte[] data;

		public X25519PrivateKeyParameters(SecureRandom random)
			: base(privateKey: false)
		{
		}

		public X25519PrivateKeyParameters(byte[] buf, int off)
			: base(privateKey: false)
		{
		}

		public X25519PrivateKeyParameters(Stream input)
			: base(privateKey: false)
		{
		}

		public void Encode(byte[] buf, int off)
		{
		}

		public byte[] GetEncoded()
		{
			return null;
		}

		public X25519PublicKeyParameters GeneratePublicKey()
		{
			return null;
		}

		public void GenerateSecret(X25519PublicKeyParameters publicKey, byte[] buf, int off)
		{
		}
	}
}
