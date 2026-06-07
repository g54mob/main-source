using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class DerSetGenerator : DerGenerator
	{
		private readonly MemoryStream _bOut;

		public DerSetGenerator(Stream outStream)
			: base(null)
		{
		}

		public DerSetGenerator(Stream outStream, int tagNo, bool isExplicit)
			: base(null)
		{
		}

		public override void AddObject(Asn1Encodable obj)
		{
		}

		public override Stream GetRawOutputStream()
		{
			return null;
		}

		public override void Close()
		{
		}
	}
}
