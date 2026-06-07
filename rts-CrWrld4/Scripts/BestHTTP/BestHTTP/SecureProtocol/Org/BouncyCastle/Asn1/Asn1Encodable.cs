namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public abstract class Asn1Encodable : IAsn1Convertible
	{
		public const string Der = "DER";

		public const string Ber = "BER";

		public byte[] GetEncoded()
		{
			return null;
		}

		public byte[] GetEncoded(string encoding)
		{
			return null;
		}

		public byte[] GetDerEncoded()
		{
			return null;
		}

		public sealed override int GetHashCode()
		{
			return 0;
		}

		public sealed override bool Equals(object obj)
		{
			return false;
		}

		public abstract Asn1Object ToAsn1Object();
	}
}
