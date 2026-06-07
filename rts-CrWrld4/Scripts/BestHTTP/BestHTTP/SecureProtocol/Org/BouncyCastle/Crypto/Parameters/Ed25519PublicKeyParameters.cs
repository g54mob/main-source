using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public sealed class Ed25519PublicKeyParameters : AsymmetricKeyParameter
	{
		public static readonly int KeySize;

		private readonly byte[] data;

		public Ed25519PublicKeyParameters(byte[] buf, int off)
			: base(privateKey: false)
		{
		}

		public Ed25519PublicKeyParameters(Stream input)
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
	}
}
