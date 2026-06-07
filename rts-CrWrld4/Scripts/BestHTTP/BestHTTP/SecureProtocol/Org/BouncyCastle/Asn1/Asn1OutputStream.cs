using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class Asn1OutputStream : DerOutputStream
	{
		public Asn1OutputStream(Stream os)
			: base(null)
		{
		}

		public override void WriteObject(object obj)
		{
		}
	}
}
