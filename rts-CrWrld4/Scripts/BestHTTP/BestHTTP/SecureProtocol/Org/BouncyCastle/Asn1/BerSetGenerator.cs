using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class BerSetGenerator : BerGenerator
	{
		public BerSetGenerator(Stream outStream)
			: base(null)
		{
		}

		public BerSetGenerator(Stream outStream, int tagNo, bool isExplicit)
			: base(null)
		{
		}
	}
}
