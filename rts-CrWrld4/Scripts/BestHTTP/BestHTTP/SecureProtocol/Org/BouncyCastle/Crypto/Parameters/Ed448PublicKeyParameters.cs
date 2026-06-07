using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public sealed class Ed448PublicKeyParameters : AsymmetricKeyParameter
	{
		public static readonly int KeySize;

		private readonly byte[] data;

		public Ed448PublicKeyParameters(byte[] buf, int off)
			: base(privateKey: false)
		{
		}

		public Ed448PublicKeyParameters(Stream input)
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
