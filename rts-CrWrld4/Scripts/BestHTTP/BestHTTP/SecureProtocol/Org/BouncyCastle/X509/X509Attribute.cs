using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509
{
	public class X509Attribute : Asn1Encodable
	{
		private readonly AttributeX509 attr;

		public string Oid => null;

		internal X509Attribute(Asn1Encodable at)
		{
		}

		public X509Attribute(string oid, Asn1Encodable value)
		{
		}

		public X509Attribute(string oid, Asn1EncodableVector value)
		{
		}

		public Asn1Encodable[] GetValues()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
