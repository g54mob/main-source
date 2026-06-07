namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerOctetString : Asn1OctetString
	{
		public DerOctetString(byte[] str)
			: base(null)
		{
		}

		public DerOctetString(IAsn1Convertible obj)
			: base(null)
		{
		}

		public DerOctetString(Asn1Encodable obj)
			: base(null)
		{
		}

		internal override void Encode(DerOutputStream derOut)
		{
		}

		internal static void Encode(DerOutputStream derOut, byte[] bytes, int offset, int length)
		{
		}
	}
}
