namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class BerSequenceParser : Asn1SequenceParser, IAsn1Convertible
	{
		private readonly Asn1StreamParser _parser;

		internal BerSequenceParser(Asn1StreamParser parser)
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
