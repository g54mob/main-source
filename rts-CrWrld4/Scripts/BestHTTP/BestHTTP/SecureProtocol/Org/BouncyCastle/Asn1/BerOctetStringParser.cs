using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class BerOctetStringParser : Asn1OctetStringParser, IAsn1Convertible
	{
		private readonly Asn1StreamParser _parser;

		internal BerOctetStringParser(Asn1StreamParser parser)
		{
		}

		public Stream GetOctetStream()
		{
			return null;
		}

		public Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
