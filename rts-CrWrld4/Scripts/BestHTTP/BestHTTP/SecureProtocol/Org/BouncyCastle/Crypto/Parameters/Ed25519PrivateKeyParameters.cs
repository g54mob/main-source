using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Rfc8032;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public sealed class Ed25519PrivateKeyParameters : AsymmetricKeyParameter
	{
		public static readonly int KeySize;

		public static readonly int SignatureSize;

		private readonly byte[] data;

		private Ed25519PublicKeyParameters cachedPublicKey;

		public Ed25519PrivateKeyParameters(SecureRandom random)
			: base(privateKey: false)
		{
		}

		public Ed25519PrivateKeyParameters(byte[] buf, int off)
			: base(privateKey: false)
		{
		}

		public Ed25519PrivateKeyParameters(Stream input)
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

		public Ed25519PublicKeyParameters GeneratePublicKey()
		{
			return null;
		}

		public void Sign(Ed25519.Algorithm algorithm, Ed25519PublicKeyParameters publicKey, byte[] ctx, byte[] msg, int msgOff, int msgLen, byte[] sig, int sigOff)
		{
		}

		public void Sign(Ed25519.Algorithm algorithm, byte[] ctx, byte[] msg, int msgOff, int msgLen, byte[] sig, int sigOff)
		{
		}
	}
}
