using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class BerGenerator : Asn1Generator
	{
		private bool _tagged;

		private bool _isExplicit;

		private int _tagNo;

		protected BerGenerator(Stream outStream)
			: base(null)
		{
		}

		public BerGenerator(Stream outStream, int tagNo, bool isExplicit)
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

		private void WriteHdr(int tag)
		{
		}

		protected void WriteBerHeader(int tag)
		{
		}

		protected void WriteBerBody(Stream contentStream)
		{
		}

		protected void WriteBerEnd()
		{
		}
	}
}
