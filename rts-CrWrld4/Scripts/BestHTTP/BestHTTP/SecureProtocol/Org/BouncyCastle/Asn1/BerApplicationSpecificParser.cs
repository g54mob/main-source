namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class BerApplicationSpecificParser : IAsn1ApplicationSpecificParser, IAsn1Convertible
	{
		private readonly int tag;

		private readonly Asn1StreamParser parser;

		internal BerApplicationSpecificParser(int tag, Asn1StreamParser parser)
		{
		}

		public IAsn1Convertible ReadObject()
		{
			return null;
		}

		public Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
