namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Misc
{
	public class Cast5CbcParameters : Asn1Encodable
	{
		private readonly DerInteger keyLength;

		private readonly Asn1OctetString iv;

		public int KeyLength => 0;

		public static Cast5CbcParameters GetInstance(object o)
		{
			return null;
		}

		public Cast5CbcParameters(byte[] iv, int keyLength)
		{
		}

		private Cast5CbcParameters(Asn1Sequence seq)
		{
		}

		public byte[] GetIV()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
