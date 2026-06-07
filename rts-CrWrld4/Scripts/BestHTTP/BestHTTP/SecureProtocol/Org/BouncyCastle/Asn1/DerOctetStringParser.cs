using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerOctetStringParser : Asn1OctetStringParser, IAsn1Convertible
	{
		private readonly DefiniteLengthInputStream stream;

		internal DerOctetStringParser(DefiniteLengthInputStream stream)
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
