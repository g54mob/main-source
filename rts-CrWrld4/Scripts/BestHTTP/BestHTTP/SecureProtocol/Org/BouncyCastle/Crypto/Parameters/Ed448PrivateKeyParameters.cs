using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Rfc8032;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public sealed class Ed448PrivateKeyParameters : AsymmetricKeyParameter
	{
		public static readonly int KeySize;

		public static readonly int SignatureSize;

		private readonly byte[] data;

		private Ed448PublicKeyParameters cachedPublicKey;

		public Ed448PrivateKeyParameters(SecureRandom random)
			: base(privateKey: false)
		{
		}

		public Ed448PrivateKeyParameters(byte[] buf, int off)
			: base(privateKey: false)
		{
		}

		public Ed448PrivateKeyParameters(Stream input)
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

		public Ed448PublicKeyParameters GeneratePublicKey()
		{
			return null;
		}

		public void Sign(Ed448.Algorithm algorithm, Ed448PublicKeyParameters publicKey, byte[] ctx, byte[] msg, int msgOff, int msgLen, byte[] sig, int sigOff)
		{
		}

		public void Sign(Ed448.Algorithm algorithm, byte[] ctx, byte[] msg, int msgOff, int msgLen, byte[] sig, int sigOff)
		{
		}
	}
}
