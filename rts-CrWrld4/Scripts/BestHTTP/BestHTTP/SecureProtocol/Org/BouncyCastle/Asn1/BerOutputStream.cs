using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1
{
	public class BerOutputStream : DerOutputStream
	{
		public BerOutputStream(Stream os)
			: base(null)
		{
		}

		public override void WriteObject(object obj)
		{
		}
	}
}
